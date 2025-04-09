namespace CompositePattern.PayECommerce
{
    public class PaymentGateway 
    {
        private IPaymentMethod _paymentMethod;
        private IPaymentEnvironment _paymentEnvironment ;
        public PaymentGateway(IPaymentMethod paymentMethod, IPaymentEnvironment paymentEnvironment)
        {
            _paymentMethod = paymentMethod;
            _paymentEnvironment = paymentEnvironment;
        }
        public void PaymentWay(decimal amount)
        {
            bool seccess = _paymentMethod.PaymentWay(amount);
            _paymentEnvironment.Enviroment(amount, seccess);
        }
        
    }
}