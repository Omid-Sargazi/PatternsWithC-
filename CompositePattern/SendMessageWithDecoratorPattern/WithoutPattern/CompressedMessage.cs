namespace CompositePattern.SendMessageWithDecoratorPattern.WithoutPattern
{
    public class CompressedMessage
    {
        private Message _message;
        public CompressedMessage(Message message)
        {
            _message = message;
        }
        // public string Text { get; set; }
        public string Send() => $"Sending compressed: {Compress(_message.Text)}";

        private string Compress(string text)
        {
            // Simulate compression
            return $"CMP{text}";
        }
    }
}