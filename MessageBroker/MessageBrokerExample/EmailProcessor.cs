using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace MessageBroker.MessageBrokerExample
{
    public class EmailProcessor
    {
        private readonly string _hostName = "localhost";
        private readonly string _queueName = "email_queue";

        private readonly string _smtpServer;
        private readonly int _smtpPort;
        private readonly string _smtpUsername;
        private readonly string _smtpPassword;

        public EmailProcessor(string smtpServer, int smtpPort, string username, string password)
        {
            _smtpServer = smtpServer;
            _smtpPort = smtpPort;
            _smtpUsername = username;
            _smtpPassword = password;
        }

        public void StartProcessing()
        {
            var factory = new ConnectionFactory(){HostName = _hostName};
            using(var connection = factory.CreateConnection())
            using(var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue : _queueName,
                                     durable : true,
                                     exclusive : false,
                                     autoDelete : false,
                                     arguments : null);
                
                channel.BasicQos(prefetchSize: 0, prefetchCount : 1, global : false);

                var consumer = new EventingBasicConsumer(channel);

                consumer.Received += (sender, ea)=>{
                    try
                    {
                        var body = ea.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);
                        var emailMessage = JsonSerializer.Deserialize<EmailMessage>(message);

                        Console.WriteLine($"[x] ایمیل با موضوع '{emailMessage.Subject}' دریافت شد");

                        SendEmail(emailMessage);
                    
                    // تأیید دریافت و پردازش پیام
                    channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
                    }catch(Exception ex)
                    {
                        Console.WriteLine($"خطا در پردازش ایمیل: {ex.Message}");
                        channel.BasicNack(deliveryTag: ea.DeliveryTag, multiple: false, requeue: true);
                    }
                };

                channel.BasicConsume(queue : _queueName,
                                     autoAck : false,
                                     consumer : consumer);
            };
            Console.WriteLine("منتظر ایمیل‌های جدید...");
            Console.ReadLine();
        }

        private void SendEmail(EmailMessage email)
        {
              using (var client = new SmtpClient(_smtpServer, _smtpPort))
        {
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential(_smtpUsername, _smtpPassword);
            
            var mailMessage = new MailMessage
            {
                From = new MailAddress(email.From),
                Subject = email.Subject,
                Body = email.Body,
                IsBodyHtml = email.IsHtml
            };
            
            mailMessage.To.Add(email.To);
            
            // اضافه کردن پیوست‌ها
            foreach (var attachment in email.Attachments)
            {
                mailMessage.Attachments.Add(new Attachment(attachment));
            }
            
            Console.WriteLine($"در حال ارسال ایمیل به {email.To}...");
            client.Send(mailMessage);
            Console.WriteLine("ایمیل با موفقیت ارسال شد.");
        }
        }
    }
}