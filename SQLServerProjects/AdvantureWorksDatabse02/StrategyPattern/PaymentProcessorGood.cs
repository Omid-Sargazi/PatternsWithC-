using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdvantureWorksDatabse02.StrategyPattern
{
    public class PaymentProcessorGood
    {
        public delegate void PaymentMethod(decimal amount);
        private Dictionary<string, PaymentMethod> paymentMethods;
        public PaymentProcessorGood()
        {
            paymentMethods = new Dictionary<string, PaymentMethod>
            {
                ["credit"] = ProcessCreditCard,
                ["paypal"] = ProcessPaypal,
                ["bank"] = ProcessBankTransfer
            };
        }

        public void ProcessPayment(decimal amount, string method)
        {
            if (paymentMethods.ContainsKey(method))
                paymentMethods[method](amount);
            else
            {
                Console.WriteLine("Payment method not supported");
            }
        }

        public void AddPaymantMethod(string name, PaymentMethod method)
        {
            paymentMethods[name] = method;
        }

        private void ProcessBankTransfer(decimal amount)
        {
            Console.WriteLine($"Processing ${amount} via Bank Transfer");
        }

        private void ProcessPaypal(decimal amount)
        {
            Console.WriteLine($"Processing ${amount} via PayPal");
        }

        private void ProcessCreditCard(decimal amount)
        {
            Console.WriteLine($"Processing ${amount} via Credit Card");
        }
    }
}