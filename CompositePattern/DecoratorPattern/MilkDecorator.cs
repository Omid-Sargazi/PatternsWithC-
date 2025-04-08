namespace CompositePattern.DecoratorPattern
{
    public class MilkDecorator : CoffeeDecorator
    {
        public MilkDecorator(ICoffee coffee) : base(coffee)
        {
        }

        public override double GetCost()
        {
            return _coffee.GetCost() + 0.5; 
        }

        public override string GetDescription()
        {
            return _coffee.GetDescription() + ", Milk";
        }
    }
}
