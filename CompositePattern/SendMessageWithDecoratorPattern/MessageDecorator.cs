namespace CompositePattern.SendMessageWithDecoratorPattern
{
    public abstract class MessageDecorator : IMessage
    {
        protected IMessage _message;
        public MessageDecorator(IMessage message)
        {
            _message = message;
        }
        
        public abstract string Send();
    }
}