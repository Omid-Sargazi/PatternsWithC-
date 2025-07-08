namespace DesignPattern.MediatorPattern
{
    public interface IRestaurantMediator
    {
        void PlaceOrder(string order, Customer customer);
    }

    public class RestaurantMediator : IRestaurantMediator
    {
        private readonly Kitchen _kitchen = new Kitchen();
        private readonly Delivery _delivery = new Delivery();
        public void PlaceOrder(string order, Customer customer)
        {
            Console.WriteLine($"Order received from{customer}:{order}");
            _kitchen.PrepareOrder(order);
            _delivery.DeliverOrder(order, customer.Name);
        }
    }

    public class Kitchen
    {
        public void PrepareOrder(string order)
        {
            Console.WriteLine($"Kitchen preparing: {order}");
        }
    }

    public class Delivery
    {
        public void DeliverOrder(string order, string customer)
        {
            Console.WriteLine($"Delivering {order} to {customer}");
        }
    }

    public class Customer
    {
        public string Name { get; set; }
        private readonly IRestaurantMediator _mediator;
        public Customer(string name, IRestaurantMediator mediator)
        {
            _mediator = mediator;
            Name = name;
        }

        public void PlaceOrder(string order)
        {
            _mediator.PlaceOrder(order, this);
        }
    }
}