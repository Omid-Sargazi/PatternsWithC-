namespace RabbitMQ.OrderStatePattern
{
    public class NewOrderState : IOrderState
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
            Console.WriteLine("پرداخت انجام شد");
            order.SetState(new PaidOrderState());
        }

        public void Ship(Order order)
        {
            throw new NotImplementedException();
        }
    }
}