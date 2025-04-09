namespace CompositePattern.PayECommerce
{
    public interface IPaymentMethod
    {
        void PaymentWay(decimal amount);
    }
}