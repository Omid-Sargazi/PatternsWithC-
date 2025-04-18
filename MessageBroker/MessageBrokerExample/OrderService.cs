using System.Text;
using System.Text.Json;
using RabbitMQ.Client;

namespace MessageBroker.MessageBrokerExample
{
    public class OrderService
    {
       private readonly string _hostName = "localhost";
       private readonly string _queueName = "localhost";

       public void PlaceOrder(Order order)
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
                string message = JsonSerializer.Serialize(order);
                var body = Encoding.UTF8.GetBytes(message);

                var properties = channel.CreateBasicProperties();
                properties.Persistent = true;

                channel.BasicPublish(exchange : "",
                                     routingKey : _queueName,
                                     basicProperties : properties,
                                     body : body);

                Console.WriteLine($"[x] سفارش {order.OrderId} با موفقیت ارسال شد");
            }
       }
    }
}