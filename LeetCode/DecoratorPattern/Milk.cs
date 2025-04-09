namespace LeetCode.DecoratorPattern
{
    public class Milk : ICoffee
    {
        private ICoffee _coffee;
        public Milk(ICoffee coffee)
        {
            _coffee = coffee;
        }
        public string GetDescription()
        {
           return _coffee.GetDescription() + " + Milk";
        }

        public double GetPrice()
        {
           return _coffee.GetPrice() + 200;
        }
    }
}