namespace CompositePattern.PayECommerce
{
    public class PaymentGateway : IPaymentGateway
    {
        public void ProcessPayment(string payType)
        {
            // Simulate payment processing
            Console.WriteLine($"Processing {payType} payment...");
        }
    }
}