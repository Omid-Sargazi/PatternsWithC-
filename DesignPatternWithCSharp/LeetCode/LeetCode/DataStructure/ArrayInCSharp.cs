using System.Globalization;

namespace LeetCode.DataStructure
{
    public class ArrayInCSharp
    {
        int[] nums = new int[] { 1, 2, 3, 4, 5, 6 };
        public void EvenNumbers()
        {
            foreach (var num in nums)
            {
                if (num % 2 == 0)
                {
                    Console.WriteLine($"Evens numbses are: {num}");
                }
            }
        }

        public double Average()
        {
            int sum = 0;
            foreach (var num in nums)
            {
                sum += num;
            }
            return (double)sum / nums.Length;
        }

        public (int max, int min) FindMaxMin(int[] arr)
        {
            int max = arr[0];
            int min = arr[0];
            foreach (var num in arr)
            {
                if (num > max) max = num;
                if (num < min) min = num;
            }

            return (max, min);
        }

        
    }
}