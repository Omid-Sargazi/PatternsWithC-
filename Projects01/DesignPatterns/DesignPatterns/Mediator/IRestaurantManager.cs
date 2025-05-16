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

    public class Chef : IColleague
    {
        private IRestaurantManager _restaurantManager;
        public string Name { get; }

        public Chef(string name)
        {
            Name = name;
        }

        public void SetRestaurantManager(IRestaurantManager manager)
        {
            _restaurantManager = manager;
        }

        public void ReceiveNotification(string message)
        {
            Console.WriteLine($"Chef {Name} received: {message}");
            // فرض کنیم آشپز غذا رو آماده می‌کنه و خبر می‌ده
            if (message.StartsWith("Order"))
            {
                int orderId = int.Parse(message.Split(':')[0].Replace("Order ", ""));
                CompleteOrder(new Order(orderId, ""));
            }
        }

        public void CompleteOrder(Order order)
        {
            Console.WriteLine($"Chef {Name} completed order {order.Id}.");
            _restaurantManager.NotifyFoodReady(order, this);
        }
    }

     public class Waiter : IColleague
    {
        private IRestaurantManager _restaurantManager;
        public string Name { get; }

        public Waiter(string name)
        {
            Name = name;
        }

        public void SetRestaurantManager(IRestaurantManager manager)
        {
            _restaurantManager = manager;
        }

        public void PlaceOrder(Order order)
        {
            Console.WriteLine($"Waiter {Name} placed order {order.Id}.");
            _restaurantManager.SendOrder(order, this);
        }

        public void ReceiveNotification(string message)
        {
            Console.WriteLine($"Waiter {Name} received: {message}");
        }
    }
}