namespace PatternsInCSharp.BidgePattern.MessagingSystem
{
    public interface IMessageChannel
    {
        public void SendMessage(string formattedMessage);
    }

    public class EmailChannel : IMessageChannel
    {
        public void SendMessage(string formattedMessage)
        {
            Console.WriteLine($"Sent via Email: {formattedMessage}");
        }
    }

    public class SMSChannel : IMessageChannel
    {
       public void SendMessage(string formattedMessage)
        {
            Console.WriteLine($"Sent via SMS: {formattedMessage}");
        }
    }

    public abstract class MessageFormat
    {
         protected IMessageChannel _channel;

        protected MessageFormat(IMessageChannel channel)
        {
            _channel = channel;
        }

        public abstract void SendMessage(string message);
    }

    public class PlainTextMessageFormat : MessageFormat
    {
        public PlainTextMessageFormat(IMessageChannel channel) : base(channel) { }

        public override void SendMessage(string message)
        {
            _channel.SendMessage(message);
        }
    }

    public class JsonMessageFormat : MessageFormat
    {
        public JsonMessageFormat(IMessageChannel channel) : base(channel) { }

        public override void SendMessage(string message)
        {
            string jsonMessage = $"{{\"message\": \"{message}\"}}";
            _channel.SendMessage(jsonMessage);
        }
    }
}
