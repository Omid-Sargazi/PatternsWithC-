namespace PatternsInCSharp.BidgePattern.PaymentManagementSystem
{
    public enum TransactionStatus
    {
        Success,
        Failed,
        Pending,
    }

    public class PaymentDetails
    {
        private Dictionary<string, string> _details = new Dictionary<string, string>();
        public void AddDetails(string key, string value) => _details[key] = value;
        public string GetDetails(string key)=>_details.ContainsKey(key) ? _details[key] : null;
    }
    public interface IPaymentMethod
    {
        TransactionStatus ExecuteTransaction(PaymentDetails details, decimal amount);
        bool IsAvailable();
    }

    public class BankGateway : IPaymentMethod
    {
        public TransactionStatus ExecuteTransaction(PaymentDetails details, decimal amount)
        {
            string cardNumber = details.GetDetails("CardNumber");
            if(string.IsNullOrEmpty(cardNumber)||cardNumber.Length<16)
            {
                return TransactionStatus.Failed;
            }
            return TransactionStatus.Success;
        }

        public bool IsAvailable()
        {
           return true;
        }
    }

    public class PayPalGateway : IPaymentMethod
    {
        public TransactionStatus ExecuteTransaction(PaymentDetails details, decimal amount)
        {
            string walletId = details.GetDetails("WalletId");
            if (string.IsNullOrEmpty(walletId))
                return TransactionStatus.Failed;

            return amount > 100 ? TransactionStatus.Pending : TransactionStatus.Success;
        }

        public bool IsAvailable()
        {
            return true;
        }
    }

    public abstract class PaymentMethod
    {
        protected IPaymentMethod _gateway;
        protected PaymentMethod(IPaymentMethod gateway)
        {
            _gateway = gateway;
        }

        public abstract TransactionStatus ProcessPayment(decimal amount, PaymentDetails details);
        public abstract bool ValidateDetails(PaymentDetails details);
    }

    public class CreditCardPayment : PaymentMethod
    {
        public CreditCardPayment(IPaymentMethod gateway) : base(gateway)
        {
        }

        public override TransactionStatus ProcessPayment(decimal amount, PaymentDetails details)
        {
            if (!_gateway.IsAvailable())
                return TransactionStatus.Failed;

            if (!ValidateDetails(details))
                return TransactionStatus.Failed;

            return _gateway.ExecuteTransaction(details, amount);
        }

        public override bool ValidateDetails(PaymentDetails details)
        {
             string cardNumber = details.GetDetails("CardNumber");
            return !string.IsNullOrEmpty(cardNumber) && cardNumber.Length == 16;
        }
    }

    public class DigitalWalletPayment : PaymentMethod
    {
        public DigitalWalletPayment(IPaymentMethod gateway) : base(gateway)
        {
        }

        public override TransactionStatus ProcessPayment(decimal amount, PaymentDetails details)
        {
           if (!_gateway.IsAvailable())
                return TransactionStatus.Failed;

            if (!ValidateDetails(details))
                return TransactionStatus.Failed;

            return _gateway.ExecuteTransaction(details, amount);
        }

        public override bool ValidateDetails(PaymentDetails details)
        {
            string walletId = details.GetDetails("WalletId");
            return !string.IsNullOrEmpty(walletId) && walletId.StartsWith("WALLET_");
        }
    }

     public class PaymentProcessor
    {
        public TransactionStatus Process(PaymentMethod method, decimal amount, PaymentDetails details)
        {
            TransactionStatus status = method.ProcessPayment(amount, details);
            Console.WriteLine($"Processing {method.GetType().Name} of ${amount} through {method.GetType().Name}: Transaction {status}");
            return status;
        }
    }
}
