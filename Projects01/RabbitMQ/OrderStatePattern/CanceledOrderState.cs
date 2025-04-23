namespace RabbitMQ.OrderStatePattern
{
    public class CanceledOrderState : IOrderState
    {
        public void Cancel(Order order)
        {
            throw new NotImplementedException();
        }

        public void Deliver(Order order)
        {
            throw new NotImplementedException();
        }

        public string GetStateName()
        {
            throw new NotImplementedException();
        }

        public void ProcessPayment(Order order)
        {
            throw new NotImplementedException();
        }

        public void Ship(Order order)
        {
            throw new NotImplementedException();
        }
    }
}