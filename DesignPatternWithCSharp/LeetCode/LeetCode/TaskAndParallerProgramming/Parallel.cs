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
                    await Task.Delay(1000);
                }
            });

            var parallelTask = Task.Run(async () =>
            {
                for (int i = 1; i <= 10; i++)
                {
                    Console.WriteLine($"Parallel work: {i}");
                    await Task.Delay(500);
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

            

        }
    }
}