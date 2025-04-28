namespace PatternsInCSharp02.BridgePattern
{
    public interface IChannel
    {
        void Send(string message);
    }

    public class SMSChannel : IChannel
    {
        public void Send(string message)
        {
            Console.WriteLine($"Sending SMS {message}");
        }
    }

    public class EmailChannel : IChannel
    {
        public void Send(string message)
        {
            Console.WriteLine($"Sending Email {message}");
        }
    }

    public abstract class MessagingSystem
    {
        protected IChannel _channel;
        public MessagingSystem(IChannel channel)
        {
            _channel = channel;
        }

        public abstract void SendMessage(string message);
    }

    public class SMSMessagingSystem : MessagingSystem
    {
        public SMSMessagingSystem(IChannel channel) : base(channel)
        {
        }

        public override void SendMessage(string message)
        {
            Console.WriteLine("Sending SMS message");
            _channel.Send(message);
        }
    }

    public class EmailMessagingSystem : MessagingSystem
    {
        public EmailMessagingSystem(IChannel channel) : base(channel)
        {
        }

        public override void SendMessage(string message)
        {
            Console.WriteLine("Sending Email message");
            _channel.Send(message);
        }
    }
}