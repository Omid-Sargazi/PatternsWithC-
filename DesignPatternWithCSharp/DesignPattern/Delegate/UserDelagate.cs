namespace DesignPattern.Delegate
{

    public class Usserr
    {
         public string Name {get;set;}
        
        public int Age {get;set;}
    }


    public class UserDelagate
    {
        public delegate void PrintUser(Usserr user);

        public static void PrintUsers(List<Usserr> users, PrintUser printMethod)
        {
            foreach (var user in users)
            {
                printMethod(user);
            }
        }
    }

    public class TransformList
    {
        public static List<int> Transform(List<int> numbers, Func<int,int> operation)
        {
            return numbers.Select(operation).ToList();   
        }
    }

    public class OrderDelegate
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public string Customer { get; set; }
    }


    public class ProcessOrderDelegate
    {
        public static void ProcessOrders(List<OrderDelegate> orders,
            Predicate<OrderDelegate> filter,
            Func<OrderDelegate, double> getAmount,
            Action<string> notify
        )
        {
            var filteredOrders = orders.FindAll(filter);
            double total = filteredOrders.Sum(getAmount);

            notify($"Total for {filteredOrders.Count} orders:{total}");
        }
    }
}