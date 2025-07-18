namespace LeetCode.TaskAndParallerProgramming
{
    public class IncrementCounter
    {
        static int counter;
        static readonly object lockObject = new object();
        public static async Task RunIncrementCounter()
        {
            Task t1 = Task.Run(() => incrementCounter());
            Task t2 = Task.Run(() => incrementCounter());
            Task.WaitAll(t1, t2);
            Console.WriteLine($"Final Counter: {counter}"); // Expected: 2000, Actual: Less than 2000
        }

        private static void incrementCounter()
        {
            for (int i = 0; i < 1000; i++)
            {
                lock (lockObject)
                    counter++;
            }
        }
    }
}