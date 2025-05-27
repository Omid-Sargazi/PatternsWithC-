namespace PatternsInCSharp.MediatorPattern
{
    public interface IMediator
    {
        void SendMessage(string msg, User sender);
        void AddUser(User sender);
    }

    public class Mediator : IMediator
    {
        protected List<User> _users = new List<User>();

        public void AddUser(User sender)
        {
            _users.Add(sender);
            Console.WriteLine($"{sender.Name} joined the group.");
            
        }

        public void SendMessage(string msg, User sender)
        {
            Console.WriteLine($"Mediator: Broadcasting message from {sender.Name}: {msg}");
            foreach (var user in _users)
            {
                if (user != sender)
                {
                    user.Receive(msg, sender.Name);
                }
            }
        }
    }

    public abstract class BaseComponent
    {
        protected IMediator _mediator;
        public BaseComponent(IMediator mediator = null)
        {
            _mediator = mediator;
        }
        public void SetMediator(IMediator mediator)
        {
            _mediator = mediator;
        }
    }

    public class User : BaseComponent
    {
        public string Name;
        public User(string name, IMediator mediator) : base(mediator)
        {
            Name = name;
        }

        public void send(string msg)
        {
            _mediator.SendMessage(msg, this);
        }

        public void Receive(string msg, string senderName)
        {
            Console.WriteLine($"{Name} received from {senderName}: {msg}");
        }

    }


}