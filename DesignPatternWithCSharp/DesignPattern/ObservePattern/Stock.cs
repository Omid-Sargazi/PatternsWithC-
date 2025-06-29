namespace DesignPattern.ObservePattern
{

    public interface IObserver
    {
        void Upadte(decimal newPrice);
    }
    public interface IStock
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void Notify();
    }

    public class Dashboard : IObserver
    {
        public void Upadte(decimal newPrice)
        {
            Console.WriteLine($"[Dashboard] Price updated: {newPrice}");
        }
    }

    public class Logger : IObserver
    {
        public void Upadte(decimal newPrice)
        {
            Console.WriteLine($"[Logger] Logged price: {newPrice}");
        }
    }

    public class AlertSystem : IObserver
    {
        public void Upadte(decimal newPrice)
        {
            if (newPrice > 150)
                Console.WriteLine($"[Alert] Price too high: {newPrice}");
        }
    }

    public class Stock : IStock
    {
        private List<IObserver> _observers = new List<IObserver>();

        public string Symbol { get; set; }
        public decimal price { get; set; }

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

       

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void Notify()
        {
            foreach (var observer in _observers)
            {
                observer.Upadte(price);
            }
        }
    }
}