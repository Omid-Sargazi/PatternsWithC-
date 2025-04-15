namespace Patterns.MediatorPattern.Chat
{
    public class ComponentB : BaseComponent
    {
        public void SendMessage(string message)
        {
            Console.WriteLine($"ComponentB sends: {message}");
            _mediator?.Notify(this, message);
        }

        public void ReceiveMessage(string message)
        {
            Console.WriteLine($"ComponentB received: {message}");
        }
    }
}