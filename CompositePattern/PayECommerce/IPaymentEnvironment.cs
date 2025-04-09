namespace CompositePattern.PayECommerce
{
    public interface IPaymentEnvironment
    {
        public string Location { get; set; }
        void Enviroment(decimal amount, bool success);
    }
}