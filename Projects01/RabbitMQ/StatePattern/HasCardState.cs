namespace RabbitMQ.StatePattern
{
    public class HasCardState : IATMState
    {
        private readonly ATMMachine _atm;
        public HasCardState(ATMMachine aTM)
        {
            _atm = aTM;
        }
        public void EjectCard()
        {
            Console.WriteLine("✅ کارت خارج شد.");
            _atm.CurrentState = new NoCardState(_atm);
        }

        public void EnterPin()
        {
            Console.Write("🔐 لطفاً رمز را وارد کنید: ");
        }

        public void InsertCard()
        {
            Console.WriteLine("❌ کارت قبلاً وارد شده.");
        }

        public void WithdrawCash()
        {
            Console.WriteLine("❌ ابتدا باید رمز صحیح وارد کنید.");
        }
    }
}