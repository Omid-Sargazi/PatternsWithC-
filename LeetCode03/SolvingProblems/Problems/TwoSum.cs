using System.Security.Cryptography.X509Certificates;

namespace SolvingProblems.Problems
{
    public class Problems
    {
        public Dictionary<int, int> valueIndexMap = new();
        public int[] TwoSum(int[] nums, int target)
        {
            int[] result;
            for (int i = 0; i <= nums.Length - 1; i++)
            {
                int complement = target - nums[i];
                if (valueIndexMap.ContainsKey(complement))
                {
                    return new int[] { valueIndexMap[complement], i };
                }
                if (!valueIndexMap.ContainsKey(nums[i]))
                    valueIndexMap.Add(nums[i], i);
            }
            return new int[0];
        }
    }
}