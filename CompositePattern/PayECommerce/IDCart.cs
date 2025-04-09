namespace CompositePattern.PayECommerce
{
    public class IDCart : IPaymentMethod
    {
        public bool PaymentWay(decimal amount)
        {
            Console.WriteLine($"IDCard payment of {amount} processed.");
            return true;
        }
    }
}