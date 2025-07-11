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
}