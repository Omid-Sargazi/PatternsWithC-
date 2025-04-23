using System.Security.Cryptography.X509Certificates;

namespace RabbitMQ.OrderStatePattern
{
    public class Order
    {
        private IOrderState _state;
        public Order()
        {
            _state = new NewOrderState();
        }

        public void SetState(IOrderState order)
        {
            _state = order;
        }
      

        public void ProcessPayment()
        {
           _state.ProcessPayment(this);

        } 

        public void Ship()
        {
            _state.Ship(this);
        }

         public void Cancel()
        {
            _state.Cancel(this);
        }

        public string GetCurrentStateName()
        {
            return _state.GetStateName();
        }
    }
}