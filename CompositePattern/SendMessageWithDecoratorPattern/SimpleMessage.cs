namespace CompositePattern.SendMessageWithDecoratorPattern
{
    public class SimpleMessage : IMessage
    {
        public string Text { get; set; }
        public string Send()
        {
          return $"Sending {Text}";
        }
    }
}