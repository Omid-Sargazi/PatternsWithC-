using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace BehavioralPattern02.LeetCodeProblems
{
    public class TwoSum
    {
        public Dictionary<int, int> _keyValues = new Dictionary<int, int>();
        public int[] Calculate(int[] nums, int target)
        {
            
            for(int i=0; i<=nums.Length-1; i++)
            {
               if(_keyValues.ContainsKey(target - nums[i]))
                    return new int[] {_keyValues[target - nums[i]],i};
                _keyValues[nums[i]] = i;
            }

            return Array.Empty<int>();
        }
    }
}