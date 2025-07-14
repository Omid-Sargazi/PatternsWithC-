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
                     await Task.Delay(3000);
                 }
             });

            var printNumbersTask = Task.Run(async () =>
            {
                for (int i = 0; i <= 5; i++)
                {
                    Console.WriteLine($"Number: {i}");
                    await Task.Delay(2000);
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

        }
    }
}