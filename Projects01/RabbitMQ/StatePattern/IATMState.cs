namespace RabbitMQ.StatePattern
{
  public interface IATMState
  {
    void InsertCard();
    void EnterPin();
    void WithdrawCash();
    void EjectCard();
  }
}