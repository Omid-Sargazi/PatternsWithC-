namespace PatternsInCSharp02.Facade
{
    public enum OrderStatus
    {
        Success,
        Failed
    }

    public class OrderService
    {
         public string PlaceOrder(string customerName, string item)
        {
            if (string.IsNullOrEmpty(customerName) || string.IsNullOrEmpty(item))
                return null;
            return $"ORDER_{customerName}_{item}";
        }
    }

    public class KitchenService
    {
        public bool PrepareOrder(string orderId)
        {
            if (string.IsNullOrEmpty(orderId))
                return false;
            Console.WriteLine($"Preparing order {orderId}");
            return true;
        }
    }
    public class DeliveryService
    {
        public bool DispatchOrder(string orderId, string customerName)
        {
            if (string.IsNullOrEmpty(orderId))
                return false;
            Console.WriteLine($"Dispatching order {orderId} to {customerName}");
            return true;
        }
    }

    public class RestaurantFacade
    {
       private OrderService _orderService = new OrderService();
        private KitchenService _kitchenService = new KitchenService();
        private DeliveryService _deliveryService = new DeliveryService();

         public OrderStatus PlaceOrder(string customerName, string item)
        {
            string orderId = _orderService.PlaceOrder(customerName, item);
            if (orderId == null)
            {
                Console.WriteLine("Order placement failed");
                return OrderStatus.Failed;
            }

            if (!_kitchenService.PrepareOrder(orderId))
            {
                Console.WriteLine("Kitchen preparation failed");
                return OrderStatus.Failed;
            }

            if (!_deliveryService.DispatchOrder(orderId, customerName))
            {
                Console.WriteLine("Delivery dispatch failed");
                return OrderStatus.Failed;
            }

            Console.WriteLine($"Order for {customerName} ({item}) successfully placed");
            return OrderStatus.Success;
        }

    }
}