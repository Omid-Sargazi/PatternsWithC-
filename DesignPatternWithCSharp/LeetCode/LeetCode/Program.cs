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

            numbers.GetStatus(out int sum, out int count);
            Console.WriteLine($"Sum:{sum}, Count:{count}");

            string text = "Omid Sargazi";
            if (text.FindWord("Omid", out int position))
            {
                Console.WriteLine($"کلمه در موقعیت {position} پیدا شد");
            }
            else
            {
                Console.WriteLine("کلمه پیدا نشد!");
            }


            List<string> names = new List<string> { "Omid", "Saeed", "Vahid" };
            names.ForEachWithAction(name => Console.WriteLine($"Names are:{name}"));

            var stringss = numbers.Transform(n => $"Number{n}");
            Console.WriteLine(string.Join(",",stringss));
        }
    }
}