using System.Threading.Tasks;
using LeetCode.ExtentionMethod;
using LeetCode.Patterns.ChainOfResponsibility;
using LeetCode.Problem1;
using LeetCode.TaskAndParallerProgramming;

namespace LeetCode
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            IncrementCounter.RunIncrementCounter();

            List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var events = numbers.GetEvents();
            foreach (var num in events)
            {
                Console.WriteLine($"Even : {num}");
            }
        }
    }
}