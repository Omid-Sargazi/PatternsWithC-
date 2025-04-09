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
            if(_paymentMethod.PaymentWay(amount))
            {
                Console.WriteLine($"Payment of {amount} processed.");
            _paymentEnvironment.Enviroment(amount);
            }
            else
            {
                Console.WriteLine($"Payment of {amount} failed.");
            }
        }
        
    }
}