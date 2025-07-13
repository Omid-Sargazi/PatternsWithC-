using LeetCode.Patterns.ChainOfResponsibility;
using LeetCode.Problem1;

namespace LeetCode
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            //========================================
            var twoSum = new TwoSum();
            int[] nums = new int[] { 2, 12, 7, 15 };
            int target = 9;
            var resultTwoSum = twoSum.TwoSumRun(nums, target);
            for (int i = 0; i < resultTwoSum.Length; i++)
            {
                Console.WriteLine($"Locations of numbers are {resultTwoSum[i]}");
            }
            //========================================


            //========================================
            var transaction = new Transaction
            {
                UserName = "Sara",
                Amount = 900_000,
                Balance = 800_000,
                DailyLimit = 700_000,
                IsBlacklisted = true
            };

            var handkerChain = HandlerBuilder.BuildChain();
            var resultt = new TransactionResult();
            handkerChain.Execute(transaction, resultt);

            Console.WriteLine($"the end of the result");
            if (resultt.IsSuccess)
            {
                Console.WriteLine("Transaction is Ok");
            }
            else
            {
                foreach (var err in resultt.Errors)
                {
                    Console.WriteLine(err);
                }
            }
            //========================================
        }
    }
}