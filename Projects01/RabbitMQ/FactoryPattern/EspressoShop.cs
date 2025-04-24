namespace RabbitMQ.FactoryPattern
{
    public class EspressoShop : CoffeeShop
    {
        public override ICoffee CreateCoffee()
        {
            return new Espresso();
        }
    }
}