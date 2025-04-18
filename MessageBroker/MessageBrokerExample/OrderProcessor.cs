using System.Text;
using System.Text.Json;
using System.Threading.Channels;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace MessageBroker.MessageBrokerExample
{
    public class OrderProcessor
    {
        private readonly string _hostName = "localhost";
        private readonly string _queueName = "orders_queue";

        public void StartProcessing()
        {
            var factory = new ConnectionFactory() {HostName = _hostName};
            using(var connection = factory.CreateConnection())
            using(var channel = connection.CreateModel())
          {  channel.QueueDeclare(queue : _queueName,
                                 durable : true,
                                 exclusive : false,
                                 autoDelete : false,
                                 arguments : null);


            channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (sender, ea)=>{
                try
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    var order = JsonSerializer.Deserialize<Order>(message);
                    Console.WriteLine($"[x] سفارش دریافت شد: {order.OrderId} از {order.CustomerName}");


                    ProcessOrder(order);


                    channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);

                }catch(Exception ex)
                {
                    Console.WriteLine($"خطا در پردازش سفارش: {ex.Message}");
                     channel.BasicNack(deliveryTag: ea.DeliveryTag, multiple: false, requeue: true);
                }
            };

            channel.BasicConsume(queue : _queueName,
                                 autoAck : false,
                                 consumer : consumer);
             Console.WriteLine("منتظر سفارش‌های جدید...");
            Console.ReadLine();
        }
        }

        private void ProcessOrder(Order order)
        {
            Console.WriteLine($"در حال پردازش سفارش {order.OrderId}...");
        
        // شبیه‌سازی زمان پردازش
        System.Threading.Thread.Sleep(1000);
        
        // اینجا می‌توانید عملیات واقعی مثل ذخیره در دیتابیس، ارسال ایمیل و... را انجام دهید
        Console.WriteLine($"سفارش {order.OrderId} با موفقیت پردازش شد.");
        }

       
    }
}