using System.Text;
using MessageBroker.IteratorPattern;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace MessageBroker 
{
public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello");
        // اتصال به آقای خرگوش پیام‌رسان
        var factory = new ConnectionFactory() { HostName = "localhost" };
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel(); // Fixed typo: createModel -> CreateModel
        channel.QueueDeclare(queue: "payment_queue", durable: false, exclusive: false, autoDelete: false, arguments: null);

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine("پیام دریافت شد: {0}", message);
        };
        channel.BasicConsume(queue: "payment_queue", autoAck: true, consumer: consumer);
        Console.WriteLine("در حال گوش دادن... برای خروج Ctrl+C بزنید.");
        Console.ReadLine();
        string message = "یه سفارش جدید: پیتزا!";
        var body = Encoding.UTF8.GetBytes(message);

        // فرستادن پیام به صندوق
        channel.BasicPublish(exchange: "", routingKey: "payment_queue", basicProperties: null, body: body);
        Console.WriteLine("پیام فرستاده شد: {0}", message);

        var collection = new ProductCollection();
        collection.Add("laptop");
        collection.Add("phone");
        collection.Add("tablet");

        var iterator = collection.CreateIterator();
        while(iterator.MoveNext())
        {
            Console.WriteLine(iterator.Current());
        }
    }
}

}