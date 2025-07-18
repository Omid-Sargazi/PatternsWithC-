using System.Threading.Tasks;
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
        }
    }
}