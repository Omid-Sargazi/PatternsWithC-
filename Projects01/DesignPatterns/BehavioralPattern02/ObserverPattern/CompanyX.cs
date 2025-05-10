namespace BehavioralPattern02.ObserverPattern
{
    public interface IStockObserver
    {
        void Update(double stockPrice);
    }

    public class StockPriceNotifier
    {
        private List<IStockObserver> _observers;
        public StockPriceNotifier()
        {
            _observers = new List<IStockObserver>();
        }

        public void AddObserver(IStockObserver observer)
        {
            _observers.Add(observer);
        }

        public void Notify(double stockPrice)
        {
            foreach(var observer in _observers)
            {
                observer.Update(stockPrice);
            }
        }
    }
    public class CompanyX
    {
        private double _stockPrice;
        private StockPriceNotifier _notifier;
        public CompanyX(Investor investor)
        {
            _stockPrice = 100.0;
            _notifier = new StockPriceNotifier();

        }

        public void AddObserver(IStockObserver observer)
        {
            _notifier.AddObserver(observer);
        }

      

        public void SetStockPrice(double price)
        {
            _stockPrice = price;
           _notifier.Notify(price);
        }
    }


    public class Investor : IStockObserver
    {
        private string name;

        public Investor(string name)
        {
            this.name = name;
        }

        public void Update(double stockPrice)
        {
            Console.WriteLine($"{name} received update: CompanyX stock price is now {stockPrice}");
        }
    }

    public class Analyst : IStockObserver
    {
        public void Update(double stockPrice)
        {
            Console.WriteLine($"Analyst logged: CompanyX stock price changed to {stockPrice}");
        }
    }

}