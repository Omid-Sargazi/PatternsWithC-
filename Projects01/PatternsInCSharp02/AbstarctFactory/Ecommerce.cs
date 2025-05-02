using System.Collections.Concurrent;
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
    public class FedExShipping : IShippingProvider
    {
        private readonly Lazy<object> _apiClient;
        public FedExShipping()
        {
            _apiClient = new Lazy<object>(()=>{
                Console.WriteLine("Initializing FedEx API client - expensive operation");
                return new object();
            });
        }
        public string ArrangeShipping(string address, double weight)
        {
            var client = _apiClient.Value;
            Console.WriteLine($"Arranging FedEx shipping to: {address} with weight: {weight}");
            return $"FEDEX-{Guid.NewGuid().ToString().Substring(0, 8)}";
        }
    }

    public class UPSShipping : IShippingProvider
    {
        private readonly Lazy<object> _apiClient;
        public UPSShipping()
        {
            _apiClient = new Lazy<object>(()=>
            {
                Console.WriteLine("Initializing UPS API client - expensive operation");
                return new object();
            });
        }
        public string ArrangeShipping(string address, double weight)
        {
            var client = _apiClient.Value;
            Console.WriteLine($"Arranging UPS shipping to: {address} with weight: {weight}");
            return $"UPS-{Guid.NewGuid().ToString().Substring(0, 8)}";
        }
    }

    public class DHLShipping : IShippingProvider
    {
        private readonly Lazy<object> _apiClient;
        public DHLShipping()
        {
            _apiClient = new Lazy<object>(()=>
            {
                Console.WriteLine("Initializing DHL API client - expensive operation");
                return new object();
            });
        }
        public string ArrangeShipping(string address, double weight)
        {
            var client = _apiClient.Value;
            Console.WriteLine($"Arranging DHL shipping to: {address} with weight: {weight}");
            return $"DHL-{Guid.NewGuid().ToString().Substring(0, 8)}";
        }
    }

    public interface ICommerceFactory
    {
        IPaymentProcessor CreatePaymentProcessor();
        IShippingProvider CreateShippingProvider();
    }

    public class PayPalFedExFactory : ICommerceFactory
    {
        public IPaymentProcessor CreatePaymentProcessor()
        {
            return new PayPalProcessor();
        }

        public IShippingProvider CreateShippingProvider()
        {
            return new FedExShipping();
        }
    }

    public class PayPalUPSFactory : ICommerceFactory
    {
        public IPaymentProcessor CreatePaymentProcessor()
        {
            return new PayPalProcessor();
        }

        public IShippingProvider CreateShippingProvider()
        {
            return new UPSShipping();
        }
    }

    public class PayPalDHLFactory : ICommerceFactory
    {
        public IPaymentProcessor CreatePaymentProcessor()
        {
            return new PayPalProcessor();
        }

        public IShippingProvider CreateShippingProvider()
        {
            return new DHLShipping();
        }
    }

    public static class CommerceObjectPool
    {
        private static readonly ConcurrentDictionary<Type, IPaymentProcessor> PaymentProcessors = new ConcurrentDictionary<Type, IPaymentProcessor>();
        private static readonly ConcurrentDictionary<Type, IShippingProvider> ShippingProviders = new ConcurrentDictionary<Type, IShippingProvider>();

        public static T GetPaymentProcessor<T>() where T : IPaymentProcessor, new()
        {
             return (T)PaymentProcessors.GetOrAdd(typeof(T), _ => new T());
        }

        public static T GetShippingProvider<T>() where T : IShippingProvider, new()
        {
            return (T)ShippingProviders.GetOrAdd(typeof(T), _ => new T());
        }
        
        // For testing purposes - clear the pools
        public static void ClearPools()
        {
            PaymentProcessors.Clear();
            ShippingProviders.Clear();
        }
    }

}