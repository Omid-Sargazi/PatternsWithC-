namespace BehavioralPattern02.ObserverPattern
{
    public class Stock
    {
        public string Symbol {get; set;}
        public decimal Price {get; private set;}

        private MobileDisplay mobileDisplay;
        private WebDisplay webDisplay;

        public Stock(string symbol, decimal price)
        {
            Symbol = symbol;
            Price = price;

            mobileDisplay = new MobileDisplay();
            webDisplay = new WebDisplay();
        }

        public void SetPrice(decimal price)
        {
            Price = price;
            mobileDisplay.ShowPrice(Symbol, Price);
            webDisplay.ShowPrice(Symbol, Price);
        }
    }

    public class MobileDisplay
    {
        public void ShowPrice(string symbol, decimal price)
        {
            Console.WriteLine($"[Mobile] {symbol} is now {price}");
        }
    }

    public class WebDisplay
    {
        public void ShowPrice(string symbol, decimal price)
        {
            Console.WriteLine($"[Web] {symbol} is now {price}");
        }
    }
}