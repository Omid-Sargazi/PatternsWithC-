namespace PatternsInCSharp02.ObserverPattern
{
   public class Product
   {
        private string _name;
        private int _stock;
        private CustomerNotifier _customerNotifier = new CustomerNotifier();
        private WarehouseManager _warehouseManager = new WarehouseManager();
        private SalesManager _salesManager = new SalesManager();
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
            _customerNotifier.Notify(_name, _stock);
            _warehouseManager.UpdateStock(_name, _stock);
            _salesManager.GenerateReport(_name, _stock);
    }
   }
   public class CustomerNotifier
   {
        public void Notify(string productName, int stock)
        {
            Console.WriteLine($"Customer notified: {productName} is {(stock > 0 ? "now in stock!" : "out of stock!")}");
        }
   }

   public class WarehouseManager
   {
         public void UpdateStock(string productName, int stock)
        {
            Console.WriteLine($"Warehouse updated: {productName} stock set to {stock}");
        }
   }

   public class SalesManager
   {
        public void GenerateReport(string productName, int stock)
        {
            Console.WriteLine($"Sales Manager notified: {productName} stock changed to {stock}");
        }
   }
    
}