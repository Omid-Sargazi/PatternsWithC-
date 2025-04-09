namespace LeetCode.DecoratorPattern
{
    public class SimpleCoffee : ICoffee
    {
        public string GetDescription()
        {
            return "قهوه ساده";
        }

        public double GetPrice()
        {
            return 1000;
        }
    }
}