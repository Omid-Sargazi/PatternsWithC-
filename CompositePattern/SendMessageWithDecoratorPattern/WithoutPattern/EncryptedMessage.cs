namespace CompositePattern.SendMessageWithDecoratorPattern.WithoutPattern
{
    public class EncryptedMessage
    {
        private Message _message;
        public EncryptedMessage(Message message)
        {
            _message = message;
        }
        // public string Text {get; set;}
        public string Send() => $"Sending encrypted: {Encrypt(_message.Text)}";
        private string Encrypt(string text) => $"ENC{text}";
    }
}