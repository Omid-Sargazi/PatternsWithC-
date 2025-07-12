namespace DesignPattern.ChainOfResponsibility
{
    public class Order
    {
        public string CustomerName { get; set; }
        public int Quantity { get; set; }
        public int StockAvailable { get; set; }
        public bool IsBlacklisted { get; set; }
        public decimal TotalPrice { get; set; }
    }

    public enum OrderStatus
    {
        Approved,
        RejectedByStock,
        RejectedByBlacklist,
        RequiresManagerApproval
    }

    public delegate OrderStatus? OrderCheck(Order order);

    public class OrderProcessorr
    {
        private readonly List<OrderCheck> _checks = new();

        public OrderProcessorr AddCheck(OrderCheck check)
        {
            _checks.Add(check);
            return this;
        }

        public OrderStatus Process(Order order)
        {
            foreach (var check in _checks)
            {
                var result = check(order);
                if (result.HasValue && result != OrderStatus.Approved)
                {
                    return result.Value;
                }
            }
            return OrderStatus.Approved;
        }
    }
}