namespace LeetCode.DecoratorPattern
{
    public class Cream : ICoffee
    {
        private ICoffee _coffee;
        public Cream(ICoffee coffee)
        {
            _coffee = coffee;
        }
        public string GetDescription()
        {
           return _coffee.GetDescription() + " + Cream";
        }

        public double GetPrice()
        {
           return _coffee.GetPrice() + 300;
        }
    }
}