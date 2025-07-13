namespace LeetCode.Problem1
{
    public class CountUniqueElements
    {
        private HashSet<int> unique = new HashSet<int>();
        public int RunCountUniqueElements(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                unique.Add(nums[i]);
            }

            return unique.Count();
        }
    }
}