namespace MessageBroker.MediatorPattern.ChatManager
{
    public class Logger : BaseComponent
    {
        public Logger(string name, IChatMediator mediator = null) : base(name, mediator)
        {
        }
        public override void ReceiveMessage(string message)
        {
            Console.WriteLine($"[LOG] Message: {message}");
        }
    }
}