namespace BehavioralPattern02.DecoratorPattern
{
    public interface INotification
    {
        public void Send(string message);
    }
    public class BasicNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine($"Sending notification: {message}");
        }
    }

    public class NotificationDecorator : INotification
    {
        protected INotification _notification1;
        public NotificationDecorator(INotification notification)
        {
            _notification1 = notification;
        }
        public virtual void Send(string message)
        {
            _notification1.Send(message);
        }
    }

    public class EmailNotificationDecorator : NotificationDecorator
    {
        public EmailNotificationDecorator(INotification notification) : base(notification)
        {
        }
        public override void Send(string message)
        {
            Console.WriteLine("Decorating with Email channel");
            _notification1.Send($"[EMAIL] {message}");
        }
    }

    public class SMSNotificationDecorator : NotificationDecorator
    {
        public SMSNotificationDecorator(INotification notification) : base(notification)
        {
        }

        public override void Send(string message)
        {
            Console.WriteLine($"Send SMS {message}");

        }
    }

    public class PushNotificationDecorator : NotificationDecorator
    {
        public PushNotificationDecorator(INotification notification) : base(notification)
        {
        }

        public override void Send(string message)
        {
            Console.WriteLine($"Send Push Message {message}");

        }
    }

    public class EncryptionDecorator : NotificationDecorator
    {
        public EncryptionDecorator(INotification notification) : base(notification)
        {
        }
        public override void Send(string message)
        {
            string encryptedMessage = Encrypt(message);
             Console.WriteLine("Message encrypted");
            _notification1.Send(encryptedMessage);
        }

        private string Encrypt(string message)
        {
            // Simulating encryption by reversing the string
            return $"ENCRYPTED({message})";
        }
    }

    public class LoggingDecorator : NotificationDecorator
    {
        public LoggingDecorator(INotification notification) : base(notification)
        {
        }

        public override void Send(string message)
        {
            Console.WriteLine($"LOG: Sending notification at {DateTime.Now}");
            _notification1.Send(message);
            Console.WriteLine("LOG: Notification sent");
        }
    }
}