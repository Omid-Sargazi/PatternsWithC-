namespace RabbitMQ.StatePattern
{
    public class ATMMachine
    {
        public IATMState CurrentState { get; set; }

        public ATMMachine()
        {
            CurrentState = new NoCardState(this);
        }

        public void InsertCard()=>CurrentState.InsertCard();
        public void EnterPin()=>CurrentState.EnterPin();
        public void WithdrawCash()=>CurrentState.WithdrawCash();
        public void EjectCard()=>CurrentState.EjectCard();
    }
}