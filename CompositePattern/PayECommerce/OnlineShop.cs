namespace CompositePattern.PayECommerce
{
    public class OnlineShop : IPaymentEnvironment
    {
        // public string Location { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Location {get; set;}
        
        public OnlineShop()
        {
            // Location = "Online Shop";
        }
        public void Enviroment(decimal amount, bool success)
        {
            // Here you can implement the logic for the online shop environment
            // For example, you might want to log the environment and amount
            Console.WriteLine($"Online shop payment of {amount} in environment {Location}");
        }
       
    }
}