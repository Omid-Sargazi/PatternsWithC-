namespace CompositePattern.PayECommerce
{
    public class DigitalWallet : IPaymentMethod
    {
        public bool PaymentWay(decimal amount)
        {
            Console.WriteLine($"Digital Wallet payment of {amount} processed.");
            return true;
        }
    }
}