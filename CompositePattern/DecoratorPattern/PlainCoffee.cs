namespace CompositePattern.DecoratorPattern
{
    public class PlainCoffee : ICoffee
    {
        public string GetDescription()
        {
            return "Plain Coffee";
        }

        public double GetCost()
        {
            return 5.0;
        }
    }
}