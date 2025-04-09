namespace CompositePattern.SendMessageWithDecoratorPattern.WithoutPattern
{
    public class CompressedMessage
    {
        public string Text { get; set; }
        public string Send() => $"Sending compressed: {Compress(Text)}";

        private string Compress(string text)
        {
            // Simulate compression
            return $"CMP{text}";
        }
    }
}