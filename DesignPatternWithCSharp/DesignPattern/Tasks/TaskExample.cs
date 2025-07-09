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
}