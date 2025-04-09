namespace CompositePattern.PayECommerce
{
    public interface IPaymentMethod
    {
        bool PaymentWay(decimal amount);
    }
}