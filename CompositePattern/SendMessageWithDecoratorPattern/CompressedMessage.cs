namespace CompositePattern.SendMessageWithDecoratorPattern
{
    public class CompressedMessage : MessageDecorator
    {
        public CompressedMessage(IMessage message) : base(message)
        {
        }

        public override string Send()
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