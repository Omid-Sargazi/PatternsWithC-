namespace CompositePattern.SendMessageWithDecoratorPattern
{
    public class CompressedMessage:IMessage
    {
        private IMessage _message;
        public CompressedMessage(IMessage message)
        {
            _message = message;
        }

        public string Send()
        {
            return $"Sending compressed: {Compress(_message.Send())}";
        }
        private string Compress(string text)
        {
            // Simulate compression
            return $"CMP{text}";
        }
    }
}