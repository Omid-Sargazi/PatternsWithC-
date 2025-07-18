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

            var filtered = numbers.Wheree(x => x > 3);

            if (MathExtensions.Divide(10, 0, out int quotient, out int reminder))
            {
                Console.WriteLine($"خارج قسمت: {quotient}, باقی‌مانده: {reminder}");
            }
            else
            {
                Console.WriteLine("تقسیم بر صفر!");
            }

            string date = "2025-07-19";
            if (date.TryParseDate(out DateTime parsedDate))
            {
                Console.WriteLine($"تاریخ: {parsedDate.ToShortDateString()}");
            }
            else
            {
                Console.WriteLine("فرمت تاریخ نامعتبر!");
            }
        }
    }
}