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
                ["paypal"] = ProcessPayPal,
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

        public void AddPaymentMethod(string name, PaymentMethod method)
        {
            paymentMethods[name] = method;
        }

        private void ProcessCreditCard(decimal amount)
        {
            Console.WriteLine($"Processing ${amount} via Credit Card");
        }

        private void ProcessPayPal(decimal amount)
        {
            Console.WriteLine($"Processing ${amount} via PayPal");
        }

        private void ProcessBankTransfer(decimal amount)
        {
            Console.WriteLine($"Processing ${amount} via Bank Transfer");
        }
        
        
    }
}