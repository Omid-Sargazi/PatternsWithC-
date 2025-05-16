namespace DesignPatterns.Mediator
{
    public class Order
    {
        public int Id { get; }
        public string Description { get; }

        public Order(int id, string description)
        {
            Id = id;
            Description = description;
        }
    }

    public interface IRestaurantManager
    {
         void RegisterChef(Chef chef);
        void RegisterWaiter(Waiter waiter);
        void SendOrder(Order order, Waiter waiter);
        void NotifyFoodReady(Order order, Chef chef);
    }
}