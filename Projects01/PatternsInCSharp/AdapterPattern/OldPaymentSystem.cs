namespace PatternsInCSharp.AdapterPattern
{
    public class OldPaymentSystem
    {
        public void PayInDollars(int dollars)
        {
            Console.WriteLine($"Paying {dollars} dollars");
        }
    }

    public interface Pay
    {
        void Paid(int price);
    }

    public class NewPaymentSystem : Pay
    {
        private readonly OldPaymentSystem _oldPaymentSystem;
        public NewPaymentSystem(OldPaymentSystem oldPaymentSystem)
        {
            _oldPaymentSystem = oldPaymentSystem;
        }

        public void Paid(int price)
        {
            _oldPaymentSystem.PayInDollars(price);
        }

       
    }

}