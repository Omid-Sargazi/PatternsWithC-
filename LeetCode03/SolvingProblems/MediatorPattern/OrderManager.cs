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
}