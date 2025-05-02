using System.Net.NetworkInformation;

namespace PatternsInCSharp02.AbstarctFactory
{
    #region Product Interfaces
    /// <summary>
    /// Abstract payment processor interface
    /// </summary>
   public interface IPaymentProcessor
   {
        bool ProcessPayment(double amount);
   }
   /// <summary>
   /// Abstract shipping provider interface
   /// </summary>
   public interface IShippingProvider 
   {
        string ArrangeShipping(string address, double weight);
   }
    #endregion

    public class PayPalProcessor : IPaymentProcessor
    {
        private readonly Lazy<object> _apiClient;

        public PayPalProcessor()
        {
            _apiClient = new Lazy<object>(()=>
            {
                Console.WriteLine("Initializing PayPal API client - expensive operation");
                return new object();
            });
        }

        public bool ProcessPayment(double amount)
        {
            var client = _apiClient.Value;
            Console.WriteLine($"Processing payment with PayPal: ${amount}");
            return true;
        }
    }

    public class StripeProcessor : IPaymentProcessor
    {
        private readonly Lazy<object> _apiClient;
        public StripeProcessor()
        {
            _apiClient = new Lazy<object>(()=>{
                Console.WriteLine("Initializing Stripe API client - expensive operation");
                return new object();
            });
        }
        public bool ProcessPayment(double amount)
        {
           var client = _apiClient.Value;
            Console.WriteLine($"Processing payment with Stripe: ${amount}");
            return true;
        }
    }

    public class SquareProcessor : IPaymentProcessor
    {
        private readonly Lazy<object> _apiClient;
        public SquareProcessor()
        {
            _apiClient = new Lazy<object>(()=>
            {
                Console.WriteLine("Initializing Square API client - expensive operation");
                return new object();
            });
        }
        public bool ProcessPayment(double amount)
        {
            var client = _apiClient.Value;
            Console.WriteLine($"Processing payment with Square: ${amount}");
            return true;
        }
    }
}