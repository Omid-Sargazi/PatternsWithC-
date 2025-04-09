namespace CompositePattern.PayECommerce
{
    public class PhysicalStore : IPaymentEnvironment
    {
        public string Location { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        
        public PhysicalStore()
        {
            Location = "Physical Store";
        }
        public void Enviroment(decimal amount)
        {
            Console.WriteLine($"Physical store environment with {amount} {Location}");
        }
    }
}