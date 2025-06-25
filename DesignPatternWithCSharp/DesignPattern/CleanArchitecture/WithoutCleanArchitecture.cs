namespace DesignPattern.CleanArchitecture
{
    public class EmailService
    {
        public void Send(string message)
        {
            Console.WriteLine("[Email Sent]: " + message);
        }
    }

    public class OrderService
    {
        private EmailService _emailService;
        public OrderService()
        {
            _emailService = new EmailService();
        }

        private void PlaceOrder()
        {
            Console.WriteLine("Order placed successfully.");
            _emailService.Send("Your order has been placed.");
        }
    }
}