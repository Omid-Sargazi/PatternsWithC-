namespace PatternsInCSharp.MediatorPattern
{
    public interface IRestaurantMediator
    {
        void PlaceOrder(string order, Customer customer);
        void NotifyKitchen(string order);
        void NotifyCashier(string order, Customer customer);
        void NotifyWaiter(string message);
    }

    public class OrderManagementSystem : IRestaurantMediator
    {
        private readonly Kitchen _kitchen;
        private readonly Cashier _cashier;
        private readonly Waiter _waiter;
        public OrderManagementSystem(Kitchen kitchen, Cashier cashier, Waiter waiter)
        {
            _cashier = cashier;
            _kitchen = kitchen;
            _waiter = waiter;
        }
        public void NotifyCashier(string order, Customer customer)
        {
            _cashier.GenerateBill(order, customer);
        }

        public void NotifyKitchen(string order)
        {
            _kitchen.PrepareOrder(order);
        }

        public void NotifyWaiter(string message)
        {
            _waiter.ReceiveNotification(message);
        }

        public void PlaceOrder(string order, Customer customer)
        {
            Console.WriteLine($"سفارش جدید: {order} از {customer.Name}");
            NotifyKitchen(order);
            NotifyWaiter($"سفارش {order} ثبت شد.");
            NotifyCashier(order, customer);
        }
    }

    public class Customer
    {
        private readonly IRestaurantMediator _mediator;
        public string Name { get; set; }
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

    public class Kitchen
    {
        public void PrepareOrder(string order)
        {
            Console.WriteLine($"آشپزخانه: در حال آماده‌سازی {order}");
        }
    }

    public class Cashier
    {
        public void GenerateBill(string order,Customer customer)
        {
            Console.WriteLine($"صندوق: صورتحساب برای {order} مشتری {customer.Name} آماده شد.");
        }
    }

    public class Waiter
    {
        public void ReceiveNotification(string message)
        {
            Console.WriteLine($"گارسون: {message}");
        }
    }

}