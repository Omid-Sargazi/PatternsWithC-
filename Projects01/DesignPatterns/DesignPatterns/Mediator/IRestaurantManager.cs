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

    public interface IColleague
    {
        void ReceiveNotification(string message);
    }

    public class RestaurantManager
    {
         private readonly List<Chef> _chefs = new List<Chef>();
        private readonly List<Waiter> _waiters = new List<Waiter>();
        private readonly Dictionary<int, Waiter> _orderToWaiter = new Dictionary<int, Waiter>();

        public void RegisterChef(Chef chef)
        {
            _chefs.Add(chef);
            chef.SetRestaurantManager(this);
            Console.WriteLine($"Chef {chef.Name} registered.");
        }

        public void RegisterWaiter(Waiter waiter)
        {
            _waiters.Add(waiter);
            waiter.SetRestaurantManager(this);
            Console.WriteLine($"Waiter {waiter.Name} registered.");
        }

        public void SendOrder(Order order, Waiter waiter)
        {
            Console.WriteLine($"Restaurant Manager received order {order.Id} from {waiter.Name}.");
            _orderToWaiter[order.Id] = waiter; // ثبت گارسون برای سفارش
            if (_chefs.Count > 0)
            {
                Chef chef = _chefs[0]; // انتخاب ساده: اولین آشپز
                chef.ReceiveNotification($"Order {order.Id}: {order.Description}");
            }
            else
            {
                Console.WriteLine("No chefs available.");
            }
        }

        public void NotifyFoodReady(Order order, Chef chef)
        {
            Console.WriteLine($"Restaurant Manager: Order {order.Id} ready by {chef.Name}.");
            if (_orderToWaiter.TryGetValue(order.Id, out Waiter waiter))
            {
                waiter.ReceiveNotification($"Order {order.Id} is ready.");
            }
            else
            {
                Console.WriteLine($"No waiter found for order {order.Id}.");
            }
        }
    }
}