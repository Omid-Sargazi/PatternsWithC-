namespace PatternsInCSharp02.ObserverPattern
{
    public interface IStockObserverr
    {
        void Update(string symbol, decimal price);
    }

    public class MobileAppNotifier : IStockObserverr
    {
        public void Update(string symbol, decimal price)
        {
            throw new NotImplementedException();
        }
    }

    public class MarketAnalyst : IStockObserverr
    {
        public void Update(string symbol, decimal price)
        {
            throw new NotImplementedException();
        }
    }
    public class TradingSystem : IStockObserverr
    {
        public void Update(string symbol, decimal price)
        {
            throw new NotImplementedException();
        }
    }

    public class Stock
    {
        private string _symbol;
        private decimal _price;
        private List<IStockObserverr> _observer = new List<IStockObserverr>();

        public void AddObserver(IStockObserverr observer)
        {
            _observer.Add(observer);
            NotifyObservers();
        }


        private void NotifyObservers()
        {
            foreach(var observer in _observer)
            {
                observer.Update(_symbol, _price);
            }
        }
       
    }
}