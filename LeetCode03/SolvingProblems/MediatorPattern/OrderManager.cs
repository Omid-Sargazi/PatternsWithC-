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
    }

    public class Inventory : Component
    {
        public Inventory(IOrderMediator orderMediator, string name) : base(orderMediator, name)
        {
        }
    }

    public class Payment : Component
    {
        public Payment(IOrderMediator orderMediator, string name) : base(orderMediator, name)
        {
        }
    }

    public class Notification : Component
    {
        public Notification(IOrderMediator orderMediator, string name) : base(orderMediator, name)
        {
        }
    }
}