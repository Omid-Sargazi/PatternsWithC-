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
    public class Inventory
    {
        private int _stock;
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
    }
}