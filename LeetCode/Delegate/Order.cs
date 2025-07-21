namespace LeetCode.Delegate
{
    public class Order
    {
        public string CustomerName { get; set; }
        public decimal Amount { get; set; }
    }

    public class OrderProcessor
    {
        public delegate bool OrderFilter(Order order);
        public  void ProcessOrders(List<Order> orders, OrderFilter filter)
        {
            foreach (var order in orders)
            {
                if (filter(order))
                    Console.WriteLine($"🌟 Special Order: {order.CustomerName} - {order.Amount:C}");
                else
                    Console.WriteLine($"Regular Order: {order.CustomerName} - {order.Amount:C}");
            }
        }
    }

    public class ClientRunOrder
    {
        public static void Run()
        {
            var orders = new List<Order>
            {
                new Order { CustomerName = "Ali", Amount = 500 },
                new Order { CustomerName = "VIP Client", Amount = 200 },
                new Order { CustomerName = "Sara", Amount = 50 }
            };

            var processor = new OrderProcessor();
            OrderProcessor.OrderFilter special = o => o.Amount >= 300 || o.CustomerName.Contains("VIP");
            processor.ProcessOrders(orders, special);
        }
    }
}