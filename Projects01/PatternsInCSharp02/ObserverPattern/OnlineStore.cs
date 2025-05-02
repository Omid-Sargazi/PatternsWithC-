namespace PatternsInCSharp02.ObserverPattern
{
    public interface IStockObserver
    {
        void Update(string productName, int stock);
    }
   public class Product
   {
        private string _name;
        private int _stock;
        private List<IStockObserver> _observers = new List<IStockObserver>();

        public void AddObserver(IStockObserver stockObserver)
        {
            _observers.Add(stockObserver);
        }

        public void RemoveObserver(IStockObserver stockObserver)
        {
            _observers.Remove(stockObserver);
        }
      
        public Product(string name, int stock)
        {
            _name = name;
            _stock = stock;
        }
    public void UpdateStock(int newStock)
    {
        _stock = newStock;
        Console.WriteLine($"Product '{_name}' stock changed to {_stock}");

            // Directly notify all components
          NotifyObservers();
    }

    private void NotifyObservers()
    {
        foreach(var observer in _observers)
        {
            observer.Update(_name, _stock);
        }
    }
   }
   public class CustomerNotifier : IStockObserver
   {
        public void Update(string productName, int stock)
        {
            Console.WriteLine($"Customer notified: {productName} is {(stock > 0 ? "now in stock!" : "out of stock!")}");
        }
   }

   public class WarehouseManager : IStockObserver
   {
         public void Update(string productName, int stock)
        {
            Console.WriteLine($"Warehouse updated: {productName} stock set to {stock}");
        }
   }

   public class SalesManager : IStockObserver
   {
        public void Update(string productName, int stock)
        {
            Console.WriteLine($"Sales Manager notified: {productName} stock changed to {stock}");
        }
   }
    
}