namespace CompositePattern.PayECommerce
{
    public interface IPaymentGateway
    {
        void ProcessPayment(string payType);
    }
}