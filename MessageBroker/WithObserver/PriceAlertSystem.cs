namespace MessageBroker.WithObserver
{
    public class PriceAlertSystem : IStockPriceListener
    {
       private readonly decimal _thresholdPrice;

        public PriceAlertSystem(string stockSymbol, decimal alertPrice)
        {
            _stockSymbol = stockSymbol;
            _alertPrice = alertPrice;
        }

        public void OnStockPriceChanged(string symbol, decimal price)
        {
            if (symbol == _stockSymbol && price >= _alertPrice)
            {
                Console.WriteLine($"هشدار: قیمت سهام {_stockSymbol} به {_alertPrice} یا بیشتر رسید!");
            }
        }
    }
}