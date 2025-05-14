namespace BehavioralPattern02.BridgePattern
{
    public interface IProcessingStrategy
    {
        void Process(decimal amount);
    }

    public interface IPaymentMethod
    {
        void ExecutePayment(decimal amount);
    }

    public class FastProcessing : IProcessingStrategy
    {
        public void Process(decimal amount)
        {
            Console.WriteLine($"Processing {amount:C} in Fast mode");
        }
    }

    public class SecureProcessing : IProcessingStrategy
    {
        public void Process(decimal amount)
        {
            Console.WriteLine($"Processing {amount:C} in Secure mode");
        }
    }


    public class CreditCardMethod : IPaymentMethod
    {
        public void ExecutePayment(decimal amount)
        {
            
            Console.WriteLine($"Processing {amount:C} with Credit Card (Fast mode)");
        }

       
    }

    public class PayPalMethod : IPaymentMethod
    {
        public void ExecutePayment(decimal amount)
        {
            Console.WriteLine($"Executing payment of {amount:C} via PayPal");
        }
    }

    


    public class CreditCardSecure
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing {amount:C} with Credit Card (Secure mode)");
        }
    }

    public class PayPalFast
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing {amount:C} with PayPal (Fast mode)");
        }
    }

    public class PayPalSecure
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing {amount:C} with PayPal (Secure mode)");
        }
    }

    public abstract class Payment
    {
        protected IPaymentMethod _paymentMethod;
        protected IProcessingStrategy _processingStrategy;
        public Payment(IPaymentMethod paymentMethod, IProcessingStrategy processingStrategy)
        {
            _paymentMethod = paymentMethod;
            _processingStrategy = processingStrategy;
        }

        public abstract void ProcessPayment(decimal amount);
    }

    public class StandardPayment : Payment
    {
        public StandardPayment(IPaymentMethod paymentMethod, IProcessingStrategy processingStrategy) : base(paymentMethod, processingStrategy)
        {
        }

        public override void ProcessPayment(decimal amount)
        {
           _processingStrategy.Process(amount);
           _paymentMethod.ExecutePayment(amount);
        }
    }
}