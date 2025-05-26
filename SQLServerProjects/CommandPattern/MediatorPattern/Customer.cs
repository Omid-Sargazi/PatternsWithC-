using System.Security;

namespace CommandPattern.MediatorPattern
{
    public class Customer
    {
        public string Name { get; set; }
        private List<Waiter> Waiters = new List<Waiter>();
        public Customer(string name)
        {
            Name = name;
        }

        public void AssignWaiter(Waiter waiter)
        {
            Waiters.Add(waiter);
        }

        public void PlaceOrder(string order)
        {
            Console.WriteLine($"{Name} placed order: {order}");
        }
    }

    public class Chef
    {
         public string Name { get; }

    public Chef(string name)
    {
        Name = name;
    }

    public void PrepareOrder(string order, Waiter waiter)
    {
        Console.WriteLine($"{Name} preparing order: {order}");
        // فرض می‌کنیم غذا آماده شده است
        waiter.DeliverFood(order, this);
    }
    }

    public class Waiter
    {
        public string Name { get; }
        private List<Chef> chefs = new List<Chef>();
        private List<Waiter> otherWaiters = new List<Waiter>();
        
        public Waiter(string name)
    {
        Name = name;
    }

    public void AssignChef(Chef chef)
    {
        chefs.Add(chef);
    }

    public void AddOtherWaiter(Waiter waiter)
    {
        otherWaiters.Add(waiter);
    }

    public void ReceiveOrder(string order, Customer customer)
    {
        Console.WriteLine($"{Name} received order from {customer.Name}: {order}");
        foreach (var chef in chefs)
        {
            chef.PrepareOrder(order, this);
        }
    }

    public void DeliverFood(string order, Chef chef)
    {
        Console.WriteLine($"{Name} delivering food to customer: {order} from {chef.Name}");
        // اطلاع‌رسانی به سایر گارسون‌ها
        foreach (var waiter in otherWaiters)
        {
            waiter.NotifyOrderCompleted(order, chef);
        }
    }

    public void NotifyOrderCompleted(string order, Chef chef)
    {
        Console.WriteLine($"{Name} notified: Order {order} completed by {chef.Name}");
    }
    }
}