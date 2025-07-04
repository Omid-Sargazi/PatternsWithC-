namespace DesignPattern.Delegate
{
    public delegate decimal CalculatePrice(decimal basePrice);
    public class OrderProcessor
    {
        public decimal ApplyStandardDiscount(decimal price) => price * 0.9m;
        public decimal ApplyPremiumDiscount(decimal price) => price * 0.9m;

        public void ProcessOrder(decimal basePrice, CalculatePrice calculator)
        {
            decimal finalPrice = calculator(basePrice);
            Console.WriteLine($"Final Price:{finalPrice}");
        }
    }   
}