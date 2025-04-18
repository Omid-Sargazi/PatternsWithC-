using System.Globalization;
using System.Text;
using System.Text.Json;
using RabbitMQ.Client;

namespace MessageBroker.MessageBrokerExample
{
    public class EmailService
    {
        private readonly string _hostName = "localhost";
        private readonly string _queueName = "email_queue";

        public void QueueEmail(EmailMessage email)
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
                string message = JsonSerializer.Serialize(email);
                var body = Encoding.UTF8.GetBytes(message);

                var properties = channel.CreateBasicProperties();
                properties.Persistent= true;

                properties.Priority = (byte)email.Priority;
                
                channel.BasicPublish(exchange : "",
                                     routingKey : _queueName,
                                     basicProperties : properties,
                                     body : body);
                
                Console.WriteLine($"[x] ایمیل با موضوع '{email.Subject}' به صف اضافه شد");
            }
        }
    }
}