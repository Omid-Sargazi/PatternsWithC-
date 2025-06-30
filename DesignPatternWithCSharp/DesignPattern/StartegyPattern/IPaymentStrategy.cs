namespace DesignPattern.StartegyPattern
{
    public interface IPaymentStrategy
    {
        bool ValidatePaymentDetails();
        bool ProcessPayment(decimal amount);
    }

    public class CreditCardPayment : IPaymentStrategy
    {
        private readonly string _cardNumber;
        private readonly string _expiryDate;
        private readonly string _cvv;

        public CreditCardPayment(string cardNumber,
        string expiryDate, string cvv)
        {
            _cardNumber = cardNumber;
            _cvv = cvv;
            _expiryDate = expiryDate;
        }
        public bool ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing credit card payment of {amount}");
            // منطق پرداخت با کارت
            return true;
        }

        public bool ValidatePaymentDetails()
        {
            Console.WriteLine($"Validating credit card: {_cardNumber}");
            return !string.IsNullOrEmpty(_cardNumber) &&
              _cardNumber.Length == 16 &&
              !string.IsNullOrEmpty(_expiryDate) &&
              !string.IsNullOrEmpty(_cvv);
        }
    }

    public class PayPalPayment : IPaymentStrategy
    {
        private readonly string _email;
        private readonly string _password;

        public PayPalPayment(string email, string password)
        {
            _email = email;
            _password = password;
        }
        public bool ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing PayPal payment of {amount}");
            // منطق پرداخت با پی پال
            return true;
        }

        public bool ValidatePaymentDetails()
        {
            Console.WriteLine($"Validating PayPal account: {_email}");
            // منطق اعتبارسنجی پی پال
            return !string.IsNullOrEmpty(_email) &&
              _email.Contains("@") &&
              !string.IsNullOrEmpty(_password);
        }
    }

    public class PaymentProcessor
    {
        private IPaymentStrategy _paymentStrategy;
        public PaymentProcessor(IPaymentStrategy paymentStrategy)
        {
            _paymentStrategy = paymentStrategy;
        }

        public bool ExecutePayment(decimal amount)
        {
            if (_paymentStrategy == null)
                throw new InvalidOperationException("Payment strategy not set");

            if (!_paymentStrategy.ValidatePaymentDetails())
            {
                Console.WriteLine("Payment details are invalid");
                return false;
            }
            return _paymentStrategy.ProcessPayment(amount);
        }
    }
}