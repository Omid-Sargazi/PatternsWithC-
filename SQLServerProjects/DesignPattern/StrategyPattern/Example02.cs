namespace DesignPattern.StrategyPattern
{
    public interface IPayStrategy
    {
        public void Pay();
    }

    public class PayByCC : IPayStrategy
    {
        public void Pay()
        {
            Console.WriteLine("Pay by CC.");
        }
    }

    public class PayByPayPal : IPayStrategy
    {
        public void Pay()
        {
            Console.WriteLine("Pay by PayPal.");

        }
    }

    public class Shpopping
    {
        private IPayStrategy _payStrategy;
        
        public Shpopping(IPayStrategy payStrategy)
        {
            _payStrategy = payStrategy;
        }

        public void performPay()
        {
            _payStrategy.Pay();
        }
    }
}