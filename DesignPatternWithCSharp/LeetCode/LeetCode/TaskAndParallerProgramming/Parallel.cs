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


            await Task.Run(async() =>
             {
                 for (int i = 0; i <= 5; i++)
                 {
                     Console.WriteLine($"Task is :{i}");
                     await Task.Delay(1000);
                 }
             });

        }
    }
}