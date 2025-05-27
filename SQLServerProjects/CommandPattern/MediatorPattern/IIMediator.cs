namespace CommandPattern.MediatorPattern
{
    public interface IIMediator
    {
        void SendMessage(string msg, Userr sender);
        void AddUser(Userr userr);
    }

    public class Mediatorr : IIMediator
    {
        public List<Userr> _users = new List<Userr>();
        public void AddUser(Userr userr)
        {
            _users.Add(userr);
        }

        public void SendMessage(string msg, Userr sender)
        {
            foreach (var user in _users)
            {
                user.Send(msg);
            }
        }
    }

    public abstract class BaseComponent
    {
        protected IIMediator _mediator;
        public BaseComponent(IIMediator mediator = null)
        {
            _mediator = mediator;
        }

        public void SetMediator(IIMediator mediator)
        {
            _mediator = mediator;
        }
    }

    public class Userr : BaseComponent
    {
        private string Name { get; set; }
        public Userr(string name, IIMediator mediator = null) : base(mediator)
        {
            Name = name;
        }
        public Userr(string name)
        {
            Name = name;
        }

        public void Send(string message)
        {
            Console.WriteLine($"{Name} sends: {message}");
            _mediator.SendMessage(message, this);

        }

        public void Receive(string msg, string senderName)
        {
            Console.WriteLine($"{Name} received from {senderName}: {msg}");
        }
    }
}