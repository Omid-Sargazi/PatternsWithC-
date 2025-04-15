namespace Patterns.MediatorPattern.Chat
{
    public class ComponentA : BaseComponent
    {
        public void SendMessage(string message)
        {
            Console.WriteLine($"ComponentA sends: {message}");
            _mediator?.Notify(this, message);
        }
        public void ReceiveMessage(string message)
        {
            Console.WriteLine($"ComponentA received: {message}");
        }
    }
}