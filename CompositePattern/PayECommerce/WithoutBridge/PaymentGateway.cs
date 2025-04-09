namespace CompositePattern.PayECommerce.WithoutBridge
{
    public class PaymentGateway
    {
        public void ProcessPayment(string payType)
        {
            if(payType == "IDCart")
                Console.WriteLine("Pay with ID Cart");
        }
    }
}