namespace LeetCode.Problem1
{
    public class TwoSum
    {
        private Dictionary<int, int> map = new Dictionary<int, int>();
        public int[] TwoSumRun(int[] nums, int targer)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                int complement = targer - nums[i];
                int current = nums[i];
                if (map.ContainsKey(complement))
                    return new int[] { map[complement], i };
                if (!map.ContainsKey(current))
                    map[current] = i;
            }
            return new int[] { };
        }
    }
}