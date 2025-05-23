namespace SolvingProblems.MediatorPattern
{
    public interface IOrderMediator
    {
        void Notify(Component sender, string eventName);
    }

    public abstract class Component
    {
        protected IOrderMediator _orderMediator;
        public string Name { get; set; }
        public Component(IOrderMediator orderMediator, string name)
        {
            Name = name;
            _orderMediator = orderMediator;
        }
    }

    public class Cart : Component
    {
        public Cart(IOrderMediator orderMediator, string name) : base(orderMediator, name)
        {
        }

        public void ConfirmCart()
        {
            Console.WriteLine($"{Name}: Cart confirmed.");
            _orderMediator.Notify(this, "CartConfirmed.");
        }
    }

    public class Inventory : Component
    {
        public Inventory(IOrderMediator orderMediator, string name) : base(orderMediator, name)
        {
        }

        public void CheckInventory()
        {
            Console.WriteLine($"{Name}: Inventory checked.");
            _orderMediator.Notify(this, "InventoryAvailable");
        }
    }

    public class Payment : Component
    {
        public Payment(IOrderMediator orderMediator, string name) : base(orderMediator, name)
        {
        }
        public void ProcessPayment()
        {
            Console.WriteLine($"{Name}: Payment processed.");
            _orderMediator.Notify(this, "PaymentProcessed");
        }
    }

    public class Notification : Component
    {
        public Notification(IOrderMediator orderMediator, string name) : base(orderMediator, name)
        {
        }

        public void SendNotification()
        {
            Console.WriteLine($"{Name}: Notification sent.");
        }
    }

    public class OrderMediator : IOrderMediator
    {
        private Cart _cart;
        private Inventory _inventory;
        private Payment _payment;
        private Notification _notification;
        public void SetCart(Cart cart) => _cart = cart;
        public void SetInvetory(Inventory inventory) => _inventory = inventory;
        public void SetPayment(Payment payment) => _payment = payment;
        public void SetNotification(Notification notification) => _notification = notification;
        public void Notify(Component sender, string eventName)
        {
            if (eventName == "CartConfirmed" && sender == _cart)
            {
                _inventory.CheckInventory();
            }
            else if (eventName == "InventoryAvailable" && sender == _inventory)
            {
                _payment.ProcessPayment();
            }
            else if (eventName == "PaymentProcessed" && sender == _payment)
            {
                _notification.SendNotification();
            }
        }
    }
}