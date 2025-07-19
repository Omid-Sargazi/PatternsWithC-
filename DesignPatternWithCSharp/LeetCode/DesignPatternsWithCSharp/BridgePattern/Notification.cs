using System.Formats.Tar;

namespace DesignPatternsWithCSharp.BridgePattern
{
    public interface INotification
    {
        void Send(string message);
    }

    public class EmailChannel : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($"[Email]{message}");
        }
    }

    public class SMSChannel : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($"[SMS]{message}");
        }
    }

    public abstract class Message
    {
        protected readonly INotification _notification;
        public Message(INotification notification)
        {
            _notification = notification;
        }

        public abstract void Send(string message);
    }

    public class AlertMessage : Message
    {
        public AlertMessage(INotification notification) : base(notification)
        {
        }

        public override void Send(string message)
        {
            _notification.Send($"[Alerting]{message}");
        }
    }

    public class PromotionMessage : Message
    {
        public PromotionMessage(INotification notification) : base(notification)
        {
        }

        public override void Send(string message)
        {
            _notification.Send($"[Promoting..]{message}");
        }
    }

    public static class ClientMessaga
    {
        public static void Run()
        {
            INotification smsChannel = new SMSChannel();
            INotification emaiChannel = new EmailChannel();

            var promoting = new PromotionMessage(smsChannel);
            promoting.Send("Hiii");
        }
    }

}