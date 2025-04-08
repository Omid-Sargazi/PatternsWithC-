namespace CompositePattern.Solution02
{
   public class Solution02
   {
        public int[] TwoSum(int[] nums, int targer)
        {
            Dictionary<int, int> seenNumbers = new Dictionary<int, int>();
            for(int i=0; i<nums.Length; i++)
            {
                int complenet = targer - nums[i];
                if(seenNumbers.ContainsKey(complenet))
                {
                    return new int[] {seenNumbers[complenet], i};
                }
                seenNumbers[nums[i]] = i;
            }
            return new int[] {};
        }
   }
}