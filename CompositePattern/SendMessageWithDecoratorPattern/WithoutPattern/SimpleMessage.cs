namespace CompositePattern.SendMessageWithDecoratorPattern.WithoutPattern
{
   public class SimpleMessage
   {
        public string Text {get; set;}
        public string Send() => $"Sending {Text}";
   }
}