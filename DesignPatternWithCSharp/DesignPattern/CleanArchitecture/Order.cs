namespace DesignPattern.CleanArchitecture
{
    public class Order
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Amount { get; set; }

        public bool Isvalid()
        {
            return Amount > 0 && !string.IsNullOrWhiteSpace(ProductName);
        }
    }

    public interface IOrderRepository
    {
        void Save(Order order);
    }

    public class PlaceOrderUseCase
    {
        private readonly IOrderRepository _orderRepo;
        public PlaceOrderUseCase(IOrderRepository orderRepo)
        {
            _orderRepo = orderRepo;
        }

        public void Execute(string productName, decimal amount)
        {
            var order = new Order { ProductName = productName, Amount = amount };
            if (!order.Isvalid())
            {
                throw new Exception("Invalid order.");
            }
            _orderRepo.Save(order);

        }
    }


    public class InMemoryOrderRepository : IOrderRepository
    {
        public void Save(Order order)
        {
            Console.WriteLine($"[Saved Order] Product: {order.ProductName}, Amount: {order.Amount}");
        }
    }
}