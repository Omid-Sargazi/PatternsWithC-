namespace PatternsInCSharp02.Decorator
{
    public interface IMessageSender
    {
        void Send(string message);
    }

    public class EmailSender : IMessageSender
    {
        public void Send(string message)
        {
            Console.WriteLine($"ارسال ایمیل: {message}");
        }
    }

    public class SmsSender : IMessageSender
    {
        public void Send(string message)
        {
            Console.WriteLine($"ارسال SMS: {message}");
        }
    }

    public abstract class MessageDecorator : IMessageSender
    {
        protected IMessageSender _messageSender;
        public MessageDecorator(IMessageSender messageSender)
        {
            _messageSender = messageSender;
        }

        public virtual void Send(string message)
        {
            _messageSender.Send(message);
        }
    }

    public class EncryptedMessageDecorator : MessageDecorator
    {
        public EncryptedMessageDecorator(IMessageSender messageSender) : base(messageSender)
        {
        }

        public void Send(string message)
        {
            string encripted = Encript(message);
            base.Send(encripted);

        }

        private string Encript(string message)
        {
            return $"Encripted {message}";
        }
    }

    public class ReadReceiptDecorator : MessageDecorator
    {
        public ReadReceiptDecorator(IMessageSender messageSender) : base(messageSender)
        {
        }

        public void Send(string message)
        {
            message += "\n[Please confirm receipt]";
            base.Send(message);
        }
    }

}