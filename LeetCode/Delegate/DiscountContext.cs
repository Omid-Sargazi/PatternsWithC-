namespace LeetCode.Delegate
{
    public delegate decimal DiscountStrategy(decimal price);
    public class DiscountContext
    {
        private DiscountStrategy _strategy;
        public void SetStrategy(DiscountStrategy strategy)
        {
            _strategy = strategy;
        }

        public decimal ApplyDiscount(decimal price)
        {
            return _strategy(price);
        }
    }

    public class StrategyDiscount
    {
        public static void Run()
        {
            var context = new DiscountContext();
            context.SetStrategy(p => p * 0.9m);
            Console.WriteLine($"Regular customer:" + context.ApplyDiscount(1000)); ;

            context.SetStrategy(p => p * 0.7m);
            context.ApplyDiscount(2000);

        }
    }
}