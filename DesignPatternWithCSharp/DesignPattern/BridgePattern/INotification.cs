namespace DesignPattern.BridgePattern
{
    public interface INotification
    {
        void Notify(string message);
    }

    public class EmailNotify : INotification
    {
        public void Notify(string message)
        {
            Console.WriteLine($"Email sending{message}");
        }
    }

    public class SMSNotify : INotification
    {
        public void Notify(string message)
        {
            Console.WriteLine($"SMS sending{message}");
        }
    }

    public abstract class BaseMessage
    {
        protected INotification _notification;
        protected BaseMessage(INotification notification)
        {
            _notification = notification;
        }

        public abstract void Send(string message);
    }

    public class WellcomeMessage : BaseMessage
    {
        public WellcomeMessage(INotification notification) : base(notification)
        {
        }

        public override void Send(string message)
        {
            _notification.Notify($"Wellcome message:{message}");
        }
    }

    public class AlerMessgae : BaseMessage
    {
        public AlerMessgae(INotification notification) : base(notification)
        {
        }

        public override void Send(string message)
        {
            _notification.Notify(message);
        }
    }

    public class AlertPassword : BaseMessage
    {
        public AlertPassword(INotification notification) : base(notification)
        {
        }

        public override void Send(string message)
        {
            _notification.Notify(message);
        }
    }
}