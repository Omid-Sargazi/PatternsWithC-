namespace CompositePattern.SendMessageWithDecoratorPattern
{
    public class EncryptedMessage : MessageDecorator
    {
        public EncryptedMessage(IMessage message) : base(message)
        {
        }

        public override string Send()
        {
            return $"Sending encrypted: {Encrypt(_message.Send())}";
        }
        private string Encrypt(string text)
        {
            return $"ENC{text}";
        }
    }
}