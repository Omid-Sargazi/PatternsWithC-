namespace RabbitMQ.FactoryPattern
{
    public class LatteShop : CoffeeShop
    {
        public override ICoffee CreateCoffee()
        {
            return new Latte();
        }
    }
}