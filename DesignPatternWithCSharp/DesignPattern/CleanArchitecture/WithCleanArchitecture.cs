namespace DesignPattern.CleanArchitecture
{
    public interface INotificationService
    {
        void Send(string message);
    }

    public class CEmailService : INotificationService
    {
        public void Send(string message)
        {
            Console.WriteLine("[Email Sent]: " + message);
        }
    }

    public class CSmsService : INotificationService
    {
        public void Send(string message)
        {
            Console.WriteLine("[SMS Sent]: " + message);
        }
    }

    public class COrderService
    {
        private readonly INotificationService _notifier;
        public COrderService(INotificationService notifier)
        {
            _notifier = notifier;
        }

        public void PlaceOrder()
        {
            Console.WriteLine("Order placed successfully.");
            _notifier.Send("Your order has been placed.");
        }
    }
}