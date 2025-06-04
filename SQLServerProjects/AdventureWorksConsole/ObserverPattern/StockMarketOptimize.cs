namespace AdventureWorksConsole.ObserverPattern
{
    public class StockMarketOptimize
    {
        private decimal _price;
        private string _stockSymbol;
        public event Action<string, decimal> PriceChanged;

        public StockMarketOptimize(string stockSymbol)
        {
            _stockSymbol = stockSymbol;
        }

        public void SetPrice(decimal price)
        {
            _price = price;
            PriceChanged?.Invoke(_stockSymbol, _price);
        }
    }

    public class TradingAppOptimize
    {
        public void Subscribe(StockMarketOptimize market)
        {
            market.PriceChanged += Update;
        }

        private void Update(string stockSymbol, decimal price)
        {
            Console.WriteLine($"اپلیکیشن معاملاتی: قیمت {stockSymbol} به {price:C} رسید.");
        }
    }

    public class WebDashboardOptimize
    {
        public void Subscribe(StockMarketOptimize market)
        {
            market.PriceChanged += Update;
        }

        private void Update(string stockSymbol, decimal price)
        {
            Console.WriteLine($"داشبورد وب: قیمت {stockSymbol} به {price:C} رسید.");
        }
    }
}