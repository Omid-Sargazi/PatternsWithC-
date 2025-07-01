using System.Reflection.Metadata.Ecma335;

namespace DesignPattern.BridgePattern
{
    public class PaymentDetails
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
        public byte[] FingerprintData { get; set; }
        public byte[] FacialRecognitionData { get; set; }
    }
    public interface IAuthenticationMethod
    {
        bool Authenticate(PaymentDetails details);
        string GetAuthenticationType();
    }

    public class BasicAuthentication : IAuthenticationMethod
    {
        public bool Authenticate(PaymentDetails details)
        {
            Console.WriteLine("Performing basic authentication");
            return !string.IsNullOrEmpty(details.Username) &&
            !string.IsNullOrEmpty(details.Password);
        }

        public string GetAuthenticationType()
        {
            return "Basic";
        }
    }

    public class AdvancedAuthentication : IAuthenticationMethod
    {
        public bool Authenticate(PaymentDetails details)
        {
            Console.WriteLine("Performing advanced authentication with 2FA");
            return string.IsNullOrEmpty(details.Username) &&
            string.IsNullOrEmpty(details.Password)
            && string.IsNullOrEmpty(details.Token);
        }

        public string GetAuthenticationType()
        {
            return "Advanced";
        }
    }

    public class BiometricAuthentication : IAuthenticationMethod
    {
        public bool Authenticate(PaymentDetails details)
        {
            Console.WriteLine("Performing biometric authentication");
            return details.FingerprintData != null ||
            details.FacialRecognitionData != null;
        }

        public string GetAuthenticationType()
        {
            return "Biometric";
        }
    }

    public abstract class PaymentProcessor
    {
        private readonly IAuthenticationMethod _authenticationMethod;
        public PaymentProcessor(IAuthenticationMethod authenticationMethod)
        {
            _authenticationMethod = authenticationMethod;
        }

        public abstract bool ProcessPayment(PaymentDetails details, decimal amount);

        protected bool Authenticate(PaymentDetails details)
        {
            return _authenticationMethod.Authenticate(details);
        }

        public string GetAuthenticationType()
        {
            return _authenticationMethod.GetAuthenticationType();
        }
    }

    public class CreditCardPayment : PaymentProcessor
    {
        public CreditCardPayment(IAuthenticationMethod authenticationMethod) : base(authenticationMethod)
        {
        }

        public override bool ProcessPayment(PaymentDetails details, decimal amount)
        {
            if (!Authenticate(details))
            {
                Console.WriteLine("Credit card payment authentication failed");
                return false;
            }
            Console.WriteLine($"Processing credit card payment for {amount}");
            return true;
        }
    }

    public class PayPalPayment : PaymentProcessor
    {
        public PayPalPayment(IAuthenticationMethod authenticationMethod) : base(authenticationMethod)
        {
        }

        public override bool ProcessPayment(PaymentDetails details, decimal amount)
        {
            if (!Authenticate(details))
        {
            Console.WriteLine("PayPal payment authentication failed");
            return false;
        }
        
             Console.WriteLine($"Processing PayPal payment for {amount}");
        
             return true;
        }
    }
}