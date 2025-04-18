namespace MessageBroker.MediatorPattern.ChatManager
{
    public class UserB : BaseComponent
    {
        public void SendMessage(string message)
        {
            Console.WriteLine($"UserB sends: {message}");
            _mediator?.Notify(this, message);
        }

        public void ReceiveMessage(string message)
        {
            Console.WriteLine($"UserB receives: {message}");
        }
    }
}