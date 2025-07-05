namespace DesignPattern.BridgePattern
{
    public interface IPaymentGateway
    {
        void Process(decimal amount);
    }

    public class StripeGateway : IPaymentGateway
    {
        public void Process(decimal amount)
    {
        Console.WriteLine($"Processing payment of {amount} via Stripe.");
    }
    }


    public class LocalBankGateway : IPaymentGateway
    {
        public void Process(decimal amount)
    {
        Console.WriteLine($"Processing payment of {amount} via LocalBank.");
    }
    }

    public class PayPalGateway  :IPaymentGateway
    {
        public void Process(decimal amount)
    {
        Console.WriteLine($"Processing payment of {amount} via PayPal Gateway.");
    }
    }

    public abstract class PaymentMethod
    {
        protected IPaymentGateway _paymentGateway;

    protected PaymentMethod(IPaymentGateway paymentGateway)
    {
        _paymentGateway = paymentGateway;
    }

    public abstract void ProcessPayment(decimal amount);
    }

    public class CreditCardPaymentt : PaymentMethod
    {
        public CreditCardPaymentt(IPaymentGateway paymentGateway) : base(paymentGateway) { }

    public override void ProcessPayment(decimal amount)
    {
        Console.WriteLine("Initiating Credit Card payment...");
        _paymentGateway.Process(amount);
    }
    }

    public class PayPalPaymentt : PaymentMethod
    {
        public PayPalPaymentt(IPaymentGateway paymentGateway) : base(paymentGateway) { }

    public override void ProcessPayment(decimal amount)
    {
        Console.WriteLine("Initiating PayPal payment...");
        _paymentGateway.Process(amount);
    }
    }
}