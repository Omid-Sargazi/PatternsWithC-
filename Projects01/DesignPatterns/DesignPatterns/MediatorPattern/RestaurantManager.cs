namespace DesignPatterns.MediatorPattern
{
    public class Order
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public Order(int id, string description)
        {
            Description = description;
            Id = id;
        }
    }
    public interface IRestaurantManager
    {
        void RegisterServer(Server server);
        void RegisterChef(Chef chef);
        void SendOrder(Order order, Server server);
        void NotifyFoodReady(Order order, Chef chef);
    }

    public interface IColleague
    {
        void ReceiveNotification(string message);
    }

    public class RestaurantManager : IRestaurantManager
    {
        
        public List<Chef> _chefs = new List<Chef>();
        public List<Server> _servers = new List<Server>();
        public Dictionary<int, Server> _orderToServer = new Dictionary<int, Server>();

        public void NotifyFoodReady(Order order, Chef chef)
        {
            Console.WriteLine($"Restaurant Manager: Order {order.Id} ready by {chef.Name}.");
        }

        public void RegisterChef(Chef chef)
        {
            _chefs.Add(chef);
            chef.SetRestaurantManager(this);
            Console.WriteLine($"Chef {chef.Name} registered.");
        }

        public void RegisterServer(Server server)
        {
            _servers.Add(server);
            server.SetRestaurantManager(this);
            Console.WriteLine($"Chef {server.Name} registered.");

        }

        public void SendOrder(Order order, Server server)
        {
            Console.WriteLine($"Restaurant Manager received order {order.Id} from {server.Name}.");
            _orderToServer[order.Id] = server;
            if (_chefs.Count > 0)
            {
                Chef chef = _chefs[0];
            }
            else
            {
                Console.WriteLine("No chefs available.");
            }
        }
    }

    public class Chef : IColleague
    {
        public IRestaurantManager _restaurantManager;
        public string Name;
        public Chef(string name)
        {
            Name = name;
        }

        public void ReceiveNotification(string message)
        {
            Console.WriteLine($"Chef {Name} received: {message}");
             int orderId = int.Parse(message.Split(':')[0].Replace("Order ", ""));
            if (message.StartsWith("Order"))
                _restaurantManager.NotifyFoodReady(new Order(orderId, ""), this);
        }

        public void SetRestaurantManager(IRestaurantManager restaurantManager)
        {
            _restaurantManager = restaurantManager;
        }

    }

    public class Server : IColleague
    {
        public IRestaurantManager _restaurantManager;
        public string Name;
        public Server(string server)
        {
            Name = server;
        }

        public void ReceiveNotification(string message)
        {
            Console.WriteLine($"Waiter {Name} received: {message}");
        }

        public void SetRestaurantManager(IRestaurantManager restaurantManager)
        {
            _restaurantManager = restaurantManager;
        }
    }


}