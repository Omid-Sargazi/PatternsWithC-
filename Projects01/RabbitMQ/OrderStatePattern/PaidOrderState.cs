namespace RabbitMQ.OrderStatePattern
{
    public class PaidOrderState : IOrderState
    {
        public void Cancel(Order order)
        {
             Console.WriteLine("سفارش لغو شد");
             order.SetState(new CanceledOrderState());
        }

        public void Deliver(Order order)
        {
            throw new InvalidOperationException("سفارش هنوز ارسال نشده است");
        }

        public string GetStateName()
        {
            throw new NotImplementedException();
        }

        public void ProcessPayment(Order order)
        {
            throw new InvalidOperationException("سفارش قبلاً پرداخت شده است");
        }

        public void Ship(Order order)
        {
            Console.WriteLine("سفارش ارسال شد");
            order.SetState(new ShippingOrderState());
        }
    }
}