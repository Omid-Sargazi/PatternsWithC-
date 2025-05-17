using System.Security.Cryptography.X509Certificates;

namespace SolvingProblems.Problems
{
    public class Problems
    {
        public Dictionary<int, int> keyValuePairs = new();
        public int[] TwoSum(int[] nums, int target)
        {
            int[] result;
            for (int i = 0; i <= nums.Length - 1; i++)
            {
                int complement = target - nums[i];
                if (keyValuePairs.ContainsKey(complement))
                {
                    return [keyValuePairs[complement], i];
                }
                else
                {
                    keyValuePairs[complement] = i;
                }
            }
            return [];
        }
    }
}