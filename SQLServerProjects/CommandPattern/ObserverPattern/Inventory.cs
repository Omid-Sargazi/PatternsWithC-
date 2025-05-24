namespace CommandPattern.ObserverPattern
{
    public interface IObserver
    {
        void Update(int stock);
    }

    public interface ISubject
    {
        void RegisterObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers();
    }
    public class Inventory : ISubject
    {
        private int _stock;
        private readonly List<IObserver> _observers = new List<IObserver>();

        public void RegisterObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.Update(_stock);
            }
        }

        public void UpdateStock(int newStock)
        {
            _stock = newStock;
            Console.WriteLine($"Stock updated to: {_stock}");
            NotifyObservers();
        }
    }

    public class WarehouseManager : IObserver
    {
        public void Update(int stock)
        {
            Console.WriteLine($"Warehouse Manager: Stock changed to {stock}");
        }
    }
    public class NotificationSystem : IObserver
    {
        public void Update(int stock)
        {
            Console.WriteLine($"Notification System: Stock changed to {stock}");
        }
    }
}