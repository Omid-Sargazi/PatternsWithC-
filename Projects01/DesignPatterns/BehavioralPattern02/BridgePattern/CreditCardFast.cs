namespace BehavioralPattern02.BridgePattern
{
    public class CreditCardFast
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing {amount:C} with Credit Card (Fast mode)");
        }
    }

    public class CreditCardSecure
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing {amount:C} with Credit Card (Secure mode)");
        }
    }

    public class PayPalFast
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing {amount:C} with PayPal (Fast mode)");
        }
    }

    public class PayPalSecure
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing {amount:C} with PayPal (Secure mode)");
        }
    }
}