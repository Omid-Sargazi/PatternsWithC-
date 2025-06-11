namespace AdvantureWorksDatabse02.StrategyPattern
{
    public class PaymentProcessorBad
    {
        public void ProcessPayment(decimal amount, string method)
        {
            if (method == "credit")
                Console.WriteLine($"Processing ${amount} via Credit Card");
            else if (method == "paypal")
                Console.WriteLine($"Processing ${amount} via PayPal");
            else if (method == "bank")
                Console.WriteLine($"Processing ${amount} via Bank Transfer");
        }
    }
}