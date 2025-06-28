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
            return new int[0];
        }

        // public IList<IList<int>> TwoSumPairs(int[] nums, int target)
        // {
        //     HashSet<int> seen = new HashSet<int>();
        //     HashSet<string> uniquePairs = new HashSet<string>();
        //     List<IList<int>> result = new List<IList<int>>();

        //     foreach (int num in nums)
        //     {
        //         int complement = target - num;
        //         if (seen.Contains(complement))
        //         {

        //         }
        //     }
        // }
    }
}