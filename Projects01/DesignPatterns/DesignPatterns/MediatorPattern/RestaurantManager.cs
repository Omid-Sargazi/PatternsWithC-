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

        public void NotifyFoodReady(Order order, Chef chef)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }

    public class Chef 
    {
        public IRestaurantManager _restaurantManager;
        public string Name;
        public Chef(string name)
        {
            Name = name;
        }
        public void SetRestaurantManager(IRestaurantManager restaurantManager)
        {
            _restaurantManager = restaurantManager;
        }

    }

    public class Server
    {
        public IRestaurantManager _restaurantManager;
        public string Name;
        public Server(string server)
        {
            Name = server;
        }
        public void SetRestaurantManager(IRestaurantManager restaurantManager)
        {
            _restaurantManager = restaurantManager;
        }
    }


}