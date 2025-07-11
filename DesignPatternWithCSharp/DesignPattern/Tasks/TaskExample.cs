using System.Security.Cryptography.X509Certificates;

namespace DesignPattern.Tasks
{
    public static class TaskExample
    {
        public static void RunTasks()
        {
            Task tsk = new Task(() => Console.WriteLine("Task is Running..."));
            tsk.Start();
            tsk.Wait();
            Task t = Task.Run(() => Thread.Sleep(2000));
            Thread.Sleep(2500);
            //t.Start();
            //tsk.Wait();
            Console.WriteLine($"{t.Status} : Status of Task");

            Task tt = new Task(() =>
            {
                for (int i = 1; i <= 5; i++)
                {
                    Console.WriteLine($"number: {i}");
                    Thread.Sleep(1000);
                }
            });

            tt.Start();
            tt.Wait();

            Console.WriteLine("the work have done");

        }
    }



    public class TaskExample2
    {
        public static async Task RunTask()
        {
            Task t1 = Task.Run(() => Console.WriteLine("Get all information of user"));

            Task t2 = t1.ContinueWith(prev => Console.WriteLine("save data in database"));
            Task t3 = t2.ContinueWith(prev => Console.WriteLine("send email"));

            t3.Wait();
        }


        public static async Task RunTask2()
        {
            Task<string> t4 = Task.Run(() =>
        {
            return "اطلاعات کاربر";
        });
            Task processData = t4.ContinueWith(prev =>
            {
                Console.WriteLine($"داده دریافت‌شده: {prev.Result}");
            });
        }
    }


    public class UserAsync
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }


        public static async Task CreateUser()
        {
            Task<List<UserAsync>> t5 = Task.Run(() =>
            {
                return new List<UserAsync>

               {
                    new UserAsync { Name = "Omid", IsActive = true },
                    new UserAsync { Name = "Sara", IsActive = false },
                    new UserAsync { Name = "Vahid", IsActive = false },
                    new UserAsync { Name = "Saeed", IsActive = true },
                    new UserAsync { Name = "Reza", IsActive = true },
                };
            });

            Task<List<UserAsync>> filterActive = t5.ContinueWith(prev =>
            {
                var users = prev.Result;
                return users.Where(u => u.IsActive).ToList();
            });

            Task printActive = filterActive.ContinueWith(prev =>
            {
                var activeUsers = prev.Result;
                Console.WriteLine("Active users");
                foreach (var user in activeUsers)
                {
                    Console.WriteLine($"-{user.Name}");

                }
            });

            printActive.Wait();

        }
    }

    public class SquareOfANumber
    {

        public static async Task SquareTask()
        {
            int num = 7;

            Task<int> squareTask = Task.Run(() =>
            {
                int square = num * num;
                Console.WriteLine($"square of numer is :{square}");
                return num;
            });


            Task<string> checkEvenTask = squareTask.ContinueWith(prev =>
            {
                int original = prev.Result;
                string result = (original % 2 == 0) ? "odd" : "event";
                return $"number {original} {result}";
            });

            Task finalPrint = checkEvenTask.ContinueWith(prev =>
            {
                Console.WriteLine($"{prev.Result}");
            });

            finalPrint.Wait();
        }
    }

    public class GenerateNumbers
    {
        public static async Task generateNumbers()
        {
            Task<int[]> numbers = Task.Run(() =>
            {
                Random rand = new Random();
                int[] number = new int[1000];
                for (int i = 0; i < number.Length; i++)
                {
                    number[i] = rand.Next(1, 10000);
                }
                Console.WriteLine("✅ مرحله 1: آرایه تولید شد");
                return number;
            });


            Task<int[]> filterEvens = numbers.ContinueWith(prev =>
            {
                int[] evens = prev.Result.Where(e => e % 2 == 0).ToArray();
                Console.WriteLine($"✅ مرحله 2: تعداد اعداد زوج: {evens.Length}");
                return evens;
            });


            Task<int[]> sortEvens = filterEvens.ContinueWith(prev =>
            {
                int[] soretd = prev.Result.OrderBy(n => n).ToArray();
                return soretd;
            });

            Task printTop5 = sortEvens.ContinueWith(prev =>
            {
                foreach (var item in prev.Result.Take(5))
                {
                    Console.WriteLine($"Even: {item}");
                }
            });

            printTop5.Wait();

        }

    }
    public class TaskException
    {
        public static async Task RunException()
        {
            Task t = Task.Run(() =>
            {
                throw new InvalidOperationException("This is a test for task");
            });

            try
            {
                t.Wait();
            }
            catch (AggregateException ex)
            {

                Console.WriteLine($"Error{ex.InnerException.Message}");
            }
        }

    }

    public class NegativeNumber
    {
        public static async Task RunException()
        {
            int input = -5;
            Task negative = Task.Run(() =>
            {
                if (input < 0)
                {
                    throw new ArgumentException("negative number is not valid.");
                }
                Console.WriteLine($"✅ عدد وارد شده: {input}");
            });

            try
            {
                negative.Wait();
            }
            catch (AggregateException ex)
            {
                Console.WriteLine($"error:{ex.InnerException.Message}");

            }

        }

    }

    public class FileNFoundException
    {
        public static async Task RunException()
        {
            string filePath = "data.txt";

            Task<string> readFileTask = Task.Run(() =>
            {
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException("file not found", filePath);
                }
                string content = File.ReadAllText(filePath);
                return content;
            });


            try
            {
                string content = readFileTask.Result;
                Console.WriteLine("content of file");
                Console.WriteLine(content);
            }
            catch (AggregateException ex)
            {

                foreach (var inner in ex.InnerExceptions)
                {
                    Console.WriteLine($"error:{inner.GetType().Name}=>{inner.Message}");
                }
            }
        }
    }
        
}