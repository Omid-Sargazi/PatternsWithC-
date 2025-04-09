namespace CompositePattern.SendMessageWithDecoratorPattern
{
    public class EncryptedMessage : IMessage
    {
        private IMessage _message;
       
        public EncryptedMessage(IMessage message)
        {
            _message = message;
        }
        public string Send()
        {
            return $"Sending encrypted: {Encrypt(_message.Send())}";
        }
        
        private string Encrypt(string text)=> $"ENC({text})"; 
    }
}