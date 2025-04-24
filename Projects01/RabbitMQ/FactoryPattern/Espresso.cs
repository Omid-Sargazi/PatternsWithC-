namespace RabbitMQ.FactoryPattern
{
    public class Espresso : ICoffee
    {
        public void Serve()
        {
            Console.WriteLine("Serving a strong Espresso!");
        }
    }
}