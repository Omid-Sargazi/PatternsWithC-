namespace LeetCode.DecoratorPattern
{
    public class Espresso : ICoffee
    {
        public string GetDescription()
        {
           return "ESpresso";
        }

        public double GetPrice()
        {
            return 1200;
        }
    }
}