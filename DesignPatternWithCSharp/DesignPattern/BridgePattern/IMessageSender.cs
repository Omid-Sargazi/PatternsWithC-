namespace DesignPattern.BridgePattern
{
    public interface IMessageSender
    {
        void SendMessage(string message, string recipient);
        string GetPlatformInfo();
    }

    public class IOSMessageSender : IMessageSender
    {
        public string GetPlatformInfo()
        {
            return "IOS Platform";
        }

        public void SendMessage(string message, string recipient)
        {
            Console.WriteLine($"📱 Sending via iOS to {recipient}");
            Console.WriteLine($"   Content: {message}");
        }
    }

    public class AndroidMessageSender : IMessageSender
    {
        public string GetPlatformInfo()
        {
            return "Android";
        }

        public void SendMessage(string message, string recipient)
        {
            Console.WriteLine($"🤖 Sending via Android to {recipient}");
            Console.WriteLine($"   Content: {message}");
        }
    }

    public class WebMessageSender : IMessageSender
    {
        public string GetPlatformInfo()
        {
            return "WEB";
        }

        public void SendMessage(string message, string recipient)
        {
            Console.WriteLine($"🌐 Sending via Web to {recipient}");
            Console.WriteLine($"   Content: {message}");
        }
    }

    public abstract class Messagee
    {
        protected IMessageSender _messageSender;
        public Messagee(IMessageSender messageSender)
        {
            _messageSender = messageSender;
        }

        public abstract void Send(string content, string recipient);
        public string GetInfo()
        {
            return $"Message via {_messageSender.GetPlatformInfo()}";
        }
    }
}