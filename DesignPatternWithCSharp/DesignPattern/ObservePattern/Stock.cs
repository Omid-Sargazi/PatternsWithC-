namespace DesignPattern.ObservePattern
{
    public class Stock
    {
        public string Symbol { get; set; }
        public decimal Price { get; set; }

        public void ChangePrice(decimal newPrice)
        {
            Price = newPrice;

            Console.WriteLine($"Dashboard updated for {Symbol}");
            Console.WriteLine($"Log written for {Symbol}");
            Console.WriteLine($"Alert checked for {Symbol}");
        }
    }
}