namespace CompositePattern.SendMessageWithDecoratorPattern.WithoutPattern
{
    public class Message
    {
        public string Text { get; set; }
        public string Send()=>$"Sending {Text}";
    }
}