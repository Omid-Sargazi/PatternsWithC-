namespace DesignPattern.BridgePattern
{
    public interface IPlatform
    {
        void Send(string messageType, string content);
    }

    public class IOSPlatform : IPlatform
    {
        public void Send(string messageType, string content)
        {
            Console.WriteLine($"[iOS] Sending {messageType}: {content}");
        }
    }

    public class WebPalatform : IPlatform
    {
        public void Send(string messageType, string content)
        {
            Console.WriteLine($"[Web] Sending {messageType}: {content}");
        }
    }

    public class AndroidPlatform : IPlatform
    {
        public void Send(string messageType, string content)
        {
            Console.WriteLine($"[Android] Sending {messageType}: {content}");
        }
    }

    public abstract class Message
    {
        protected readonly IPlatform _platform;

        public Message(IPlatform platform)
        {
            _platform = platform;
        }

        public abstract void Send(string content);
    }

    public class EmailMessage : Message
    {
        public EmailMessage(IPlatform platform) : base(platform)
        {
        }

        public override void Send(string content)
        {
            _platform.Send(content, "Email");
        }
    }

    public class TextMessage : Message
    {
        public TextMessage(IPlatform platform) : base(platform)
        {
        }

        public override void Send(string content)
        {
            _platform.Send("text", content);
        }
    }

}