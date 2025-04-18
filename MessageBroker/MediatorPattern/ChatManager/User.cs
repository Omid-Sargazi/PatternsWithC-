namespace MessageBroker.MediatorPattern.ChatManager
{
    public class User : BaseComponent
    {
        public User(string name, IChatMediator mediator = null) : base(name, mediator)
        {
        }

        public void SendMessage(string message)
        {
            Console.WriteLine($"UserB sends: {message}");
            _mediator?.Notify(this, message);
        }


        public override void ReceiveMessage(string message)
        {
            Console.WriteLine($"{Name} receives: {message}");
        }
    }
}