namespace CompositePattern.PayECommerce
{
    public class IDCart : IPaymentMethod
    {
        public void PaymentWay(decimal amount)
        {
            Console.WriteLine($"IDCard payment of {amount} processed.");
        }
    }
}