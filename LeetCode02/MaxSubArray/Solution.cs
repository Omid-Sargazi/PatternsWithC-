namespace LeetCode02.MaxSubArray
{
    public class Solution
    {
        public int MaxSubArray(int[] array)
        {
            if(array == null || array.Length==0) return 0;
            int max_so_far = array[0];
            int current_max = array[0];
            for(int i=0; i < array.Length; i++)
            {
                max_so_far = Math.Max(array[i],max_so_far + array[i]);
                current_max = Math.Max(current_max, max_so_far);
            }
            return max_so_far;
        }
    }
}