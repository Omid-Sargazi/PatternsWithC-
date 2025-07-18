namespace LeetCode.TaskAndParallerProgramming
{
    public class IncrementCounter
    {
        static int counter;
        static readonly object lockObject = new object();
        static List<int> numbers = new List<int>();
        public static async Task RunIncrementCounter()
        {
            Task t1 = Task.Run(() => InterLockIncrement());
            Task t2 = Task.Run(() => InterLockIncrement());
            Task t3 = Task.Run(() => AddNumbers(1));
            Task t4 = Task.Run(() => AddNumbers(1));
            Task.WaitAll(t1, t2);
            Task.WaitAll(t3, t4);
            Console.WriteLine($"Final Counter: {counter}"); // Expected: 2000, Actual: Less than 2000
            Console.WriteLine($"Count: {numbers.Count}"); // Expected: 2000, Actual: Unpredictable

        }

        private static void incrementCounter()
        {
            for (int i = 0; i < 1000; i++)
            {
                lock (lockObject)
                    counter++;
            }
        }
        private static void InterLockIncrement()
        {
            for (int i = 0; i < 1000; i++)
            {
                Interlocked.Increment(ref counter);
            }
        }

        private static void AddNumbers(int taskId)
        {
            for (int i = 0; i < 1000; i++)
            {
                lock (lockObject)
                {
                    numbers.Add(taskId * 1000 + 1);
                }
            }
        }
    }
}