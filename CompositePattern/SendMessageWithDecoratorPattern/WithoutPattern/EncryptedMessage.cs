namespace CompositePattern.SendMessageWithDecoratorPattern.WithoutPattern
{
    public class EncryptedMessage
    {
        public string Text {get; set;}
        public string Send() => $"Sending encrypted: {Encrypt(Text)}";
        private string Encrypt(string text) => $"ENC{text}";
    }
}