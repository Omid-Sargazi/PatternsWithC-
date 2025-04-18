namespace MessageBroker.MediatorPattern.ChatManager
{
    public class UserA : BaseComponent
    {
        public void SendMessage(string message)
        {
            Console.WriteLine($"UserA sends: {message}");
            _mediator?.Notify(this, message);
        }

        public void ReceiveMessage(string message)
        {
            Console.WriteLine($"UserA receives: {message}");
        }
    }
}   