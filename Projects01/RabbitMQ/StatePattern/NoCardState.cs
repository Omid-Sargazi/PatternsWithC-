namespace RabbitMQ.StatePattern
{
    public class NoCardState : IATMState
    {
       private readonly ATMMachine _atm;

       public NoCardState(ATMMachine aTM)
       {
            _atm = aTM;
       }

        public void EjectCard()
        {
            Console.WriteLine("❌ هیچ کارتی وارد نشده که بخواید خارجش کنید.");
        }

        public void EnterPin()
        {
            Console.WriteLine("❌ کارت وارد نشده. ابتدا کارت وارد کنید.");
        }

        public void InsertCard()
        {
            Console.WriteLine("✅ کارت وارد شد.");
            _atm.CurrentState =new HasCardState(_atm);
        }

        public void WithdrawCash()
        {
            Console.WriteLine("❌ نمی‌تونید پول بگیرید. کارت وارد نشده.");
        }
    }
}