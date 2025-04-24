namespace RabbitMQ.FactoryPattern
{
    public abstract class CoffeeShop
    {
        public abstract ICoffee CreateCoffee();

        public void OrderCoffee(string type)
        {
            ICoffee coffee = CreateCoffee();
            Console.WriteLine("Processing your order...");
            coffee.Serve();
        }
    }
}