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
    public bool IsPalindrome(int number)
    {
        if(number < 0) return false;
        int original  = number;
        int reverse = 0;
        while(number!=0)
        {
            int digit = number%10;
            reverse = reverse*10+digit;
            number/=10;
        }

        return original == reverse;
    }
    }

}