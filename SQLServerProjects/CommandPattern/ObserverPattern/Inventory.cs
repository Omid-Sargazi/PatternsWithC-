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
        public void UpdateStock(int newStock)
        {
            _stock = newStock;
            Console.WriteLine($"Stock updated to :{newStock}");
            NotifyNotificationSystem();
            NotifyWarehouseManager();

        }

        private void NotifyWarehouseManager()
        {
            Console.WriteLine("Warehouse Manager: Stock changed!");
        }

        private void NotifyNotificationSystem()
        {
            Console.WriteLine("Notification System: Stock changed!");
        }

        public void RegisterObserver(IObserver observer)
        {
            throw new NotImplementedException();
        }

        public void RemoveObserver(IObserver observer)
        {
            throw new NotImplementedException();
        }

        public void NotifyObservers()
        {
            throw new NotImplementedException();
        }
    }

    public class WarehouseManager : IObserver
    {
        public void Update(int stock)
        {
            throw new NotImplementedException();
        }
    }
    public class NotificationSystem : IObserver
    {
        public void Update(int stock)
        {
            throw new NotImplementedException();
        }
    }
}