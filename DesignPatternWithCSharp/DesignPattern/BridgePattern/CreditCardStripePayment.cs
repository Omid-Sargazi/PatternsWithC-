namespace DesignPattern.BridgePattern
{
    public class CreditCardStripePayment
    {
        public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing Credit Card payment of {amount} via Stripe.");
    }
    }

    public class PayPalStripePayment
    {
        public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing PayPal payment of {amount} via Stripe.");
    }
    }

    public class CreditCardLocalBankPayment
    {
        public void ProcessPayment(decimal amount)
    {
        Console.WriteLine($"Processing Credit Card payment of {amount} via LocalBank.");
    }
    }
}