namespace RabbitMQ.FactoryPattern
{
    public class Latte : ICoffee
    {
        public void Serve()
        {
            Console.WriteLine("Serving a creamy Latte!");
        }
    }
}