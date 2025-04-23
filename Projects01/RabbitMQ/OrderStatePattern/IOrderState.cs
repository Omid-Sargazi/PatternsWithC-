namespace RabbitMQ.OrderStatePattern
{
    public interface IOrderState
    {
        void ProcessPayment(Order order);
        void Ship(Order order);
        void Deliver(Order order);
        void Cancel(Order order);

        string GetStateName();
    }
}