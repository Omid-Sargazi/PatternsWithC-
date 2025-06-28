namespace DesignPattern.LeetCode
{
    public class Problem03
    {
        public int[] AllTheTriplets(int[] nums)
        {
            return [];
        }

        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (!map.ContainsKey(complement))
                {
                    map[nums[i]] = i;
                }
                if (map.ContainsKey(complement))
                {
                    return new int[] { map[complement], i };
                    
                }
            }
            return new  int[0];
        }
    }
}