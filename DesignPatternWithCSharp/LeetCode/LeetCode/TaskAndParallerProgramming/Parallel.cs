namespace LeetCode.TaskAndParallerProgramming
{
    public class TaskProgramming
    {
        public async Task RunRask()
        {
            var task = new Task(() => Console.WriteLine("This is runnig..........."));
            task.Start();
            await task;
            Task t2 = Task.Run(() =>
            {
                Console.WriteLine("Task with Run command");
                Thread.Sleep(1000);
            });
            await t2;
            // Thread.Sleep(1000);

            Console.WriteLine($"{t2.Status}: Status of Tasks");


            await Task.Run(async () =>
             {
                 for (int i = 0; i <= 5; i++)
                 {
                     Console.WriteLine($"Task is :{i}");
                     await Task.Delay(300);
                 }
             });

            var printNumbersTask = Task.Run(async () =>
            {
                for (int i = 0; i <= 5; i++)
                {
                    Console.WriteLine($"Number: {i}");
                    await Task.Delay(100);
                }
            });

            var parallelTask = Task.Run(async () =>
            {
                for (int i = 1; i <= 10; i++)
                {
                    Console.WriteLine($"Parallel work: {i}");
                    await Task.Delay(50);
                }
            });

            await Task.WhenAll(printNumbersTask, parallelTask);
            Console.WriteLine("All tasks completed!");


            int[] numbers = new int[10000];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = i;
            }

            long sum1 = 0;
            long sum2 = 0;

            var s1 = Task.Run(async () =>
            {
                for (int i = 0; i < numbers.Length / 2; i++)
                {
                    sum1 += numbers[i];

                }
            });


            var s2 = Task.Run(() =>
            {
                for (int i = numbers.Length / 2; i < numbers.Length; i++)
                {
                    sum2 += numbers[i];

                }
            });

            await Task.WhenAll(s1, s2);

            Console.WriteLine($"Total Sum is : {sum1 + sum2}");

            await Task.Run(() =>
            {
                Console.WriteLine("Input Data..");
            });

            await Task.Run(() =>
            {
                Console.WriteLine("Save Data in Database");
            });

            await Task.Run(() =>
            {
                Console.WriteLine("Send Email");
            });


            Task t11 = Task.Run(() =>
            {
                Console.WriteLine("مرحله 1: دریافت داده کاربر");
            });
            Task t22 = t11.ContinueWith((prev) =>
            {
                Console.WriteLine("مرحله 2: ذخیره در دیتابیس");
            });

            Task t33 = t22.ContinueWith(prev =>
            {
                Console.WriteLine("مرحله 3: ارسال ایمیل تایید");
            });

            t33.Wait();


            Task<string> fetchData = Task.Run(() =>
            {
                return "Omid";
            });

            Task processData = fetchData.ContinueWith(prev =>
            {
                Console.WriteLine($"داده دریافت‌شده: {prev.Result}");
            });



        }
    }
}