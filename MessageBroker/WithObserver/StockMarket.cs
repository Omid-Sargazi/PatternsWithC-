namespace MessageBroker.WithObserver
{
    public class StockMarket
    {
          private List<IStockPriceListener> _listeners = new List<IStockPriceListener>();
        private Dictionary<string, decimal> _stockPrices = new Dictionary<string, decimal>();
        
        // متدهای مدیریت شنوندگان
        public void AddListener(IStockPriceListener listener)
        {
            _listeners.Add(listener);
        }
        
        public void RemoveListener(IStockPriceListener listener)
        {
            _listeners.Remove(listener);
        }
        
        // اطلاع‌رسانی به همه شنوندگان
        private void NotifyListeners(string symbol, decimal price)
        {
            foreach (var listener in _listeners)
            {
                listener.OnStockPriceChanged(symbol, price);
            }
        }
        
        // به‌روزرسانی قیمت سهام
        public void UpdateStockPrice(string symbol, decimal price)
        {
            // ذخیره قیمت جدید
            _stockPrices[symbol] = price;
            
            // ذخیره در دیتابیس
            SavePriceToDatabase(symbol, price);
            
            // اطلاع‌رسانی به همه شنوندگان
            NotifyListeners(symbol, price);
            
            Console.WriteLine($"قیمت سهام {symbol} به {price} تغییر کرد.");
        }
        
        public decimal GetStockPrice(string symbol)
        {
            if (_stockPrices.ContainsKey(symbol))
            {
                return _stockPrices[symbol];
            }
            
            return 0; // یا exception پرتاب کنید
        }
        
        private void SavePriceToDatabase(string symbol, decimal price)
        {
            // کد ذخیره در دیتابیس
            Console.WriteLine($"ذخیره قیمت {symbol} در دیتابیس: {price}");
        }
    }
}