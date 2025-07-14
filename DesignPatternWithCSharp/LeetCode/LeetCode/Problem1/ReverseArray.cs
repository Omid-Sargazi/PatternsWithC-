using System.Globalization;

namespace LeetCode.Problem1
{
    public class ReverseArray
    {
        public static void RunReverseArray(int[] nums)
        {
            int left = 0;
            int right = nums.Length - 1;
            while (left < right)
            {
                int temp = nums[right];
                nums[right] = nums[left];
                nums[left] = temp;
                left++;
                right--;
            }
        }
    }

    public class ReverseString
    {
        public static string RunReverseString(string s)
        {
            char[] charArray = s.ToCharArray();
            int left = 0;
            int right = s.Length - 1;
            while (left < right)
            {
                char temp = charArray[left];
                charArray[left] = charArray[right];
                charArray[right] = temp;
                left++;
                right--;
            }
            return new string(charArray);
        }
    }
}