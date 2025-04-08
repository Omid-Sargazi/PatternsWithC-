namespace CompositePattern.DecoratorPattern
{
    public abstract class CoffeeDecorator : ICoffee
    {
        protected ICoffee _coffee;
        public CoffeeDecorator(ICoffee coffee)
        {
            _coffee = coffee;
        }
        public abstract double GetCost();

        public abstract string GetDescription();
    }
}