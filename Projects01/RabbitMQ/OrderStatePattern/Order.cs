using System.Security.Cryptography.X509Certificates;

namespace RabbitMQ.OrderStatePattern
{
    public class Order
    {
       public enum OrderState
       {
            New, 
            Paid, 
            Shipping,
            Delivered,
            Canceled,
        }

        public OrderState State {get; private set;} = OrderState.New;
        public void ProcessPayment()
        {
            if(State == OrderState.New)
            {
                State = OrderState.Paid;
            }else{
                throw new InvalidOperationException("پرداخت فقط برای سفارش‌های جدید مجاز است");
            }

        } 

        public void Ship()
        {
            if(State == OrderState.Paid)
            {
                State = OrderState.Shipping;
            }
            else
            {
                throw new InvalidOperationException("تحویل فقط برای سفارش‌های در حال ارسال مجاز است");
            }
        }

         public void Cancel()
    {
            if (State == OrderState.New || State == OrderState.Paid)
            {
                // لغو سفارش...
                State = OrderState.Canceled;
            }
            else
            {
                throw new InvalidOperationException("لغو فقط برای سفارش‌های جدید یا پرداخت شده مجاز است");
            }
    }
    }
}