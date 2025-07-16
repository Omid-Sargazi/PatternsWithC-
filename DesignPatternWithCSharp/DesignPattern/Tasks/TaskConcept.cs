namespace DesignPattern.Tasks
{
    public class User
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public static async Task RunTaskConcept()
        {
            Task<List<User>> createUsers = Task.Run(() =>
            {
                return new List<User>
                {
                    new User { Name = "Ali", IsActive = true },
                    new User { Name = "Sara", IsActive = false },
                    new User { Name = "Reza", IsActive = true }
                };
            });

            Task<List<User>> filterActive = createUsers.ContinueWith(prev =>
            {
                var users = prev.Result;
                return users.Where(u => u.IsActive).ToList();
            });

            Task printUser = filterActive.ContinueWith(prev =>
            {
                var activeUsers = prev.Result;
                Console.WriteLine("✅ کاربران فعال:");
                foreach (var user in activeUsers)
                {
                    Console.WriteLine($"-{user.Name}");
                }
            });
        }

    }


    public class TaskExceptions
    {
        public static async Task RunTaskExceptions()
        {
            Task t1 = Task.Run(() =>
            {
                throw new InvalidOperationException("A test of error");
            });

            try
            {
                t1.Wait();
            }
            catch (AggregateException ex)
            {
                Console.WriteLine($"error:{ex.InnerException.Message}");
            }
        }

        public static async Task SynchronizationTasks()
        {
            object _lock = new object();
            int counter = 0;
            Task t1 = Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    lock (_lock)
                    {
                        counter++;
                    }
                }
            });
            Task t2 = Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    lock (_lock)
                    {
                        counter++;
                    }
                }
            });

            Task.WaitAll(t1, t2);
            Console.WriteLine($"Counter:==========>{counter}");
        }
        
    }
}