namespace CompositePattern.PayECommerce
{
    public class PaymentGateway 
    {
        private IPaymentMethod _paymentMethod;
        public PaymentGateway(IPaymentMethod paymentMethod)
        {
            _paymentMethod = paymentMethod;
        }
        public void PaymentWay(decimal amount)
        {
            _paymentMethod.PaymentWay(amount);
        }
    }
}