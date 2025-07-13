using LeetCode.Problem1;

namespace LeetCode
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            //===========================
            var twoSum = new TwoSum();
            int[] nums = new int[] { 2, 12, 7, 15 };
            int target = 9;
            var resultTwoSum = twoSum.TwoSumRun(nums, target);
            for (int i = 0; i < resultTwoSum.Length; i++)
            {
                Console.WriteLine($"Locations of numbers are {resultTwoSum[i]}");
            }
            //===========================
        }
    }
}