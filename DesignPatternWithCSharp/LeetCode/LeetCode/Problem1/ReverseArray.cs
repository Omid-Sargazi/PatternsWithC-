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
}