namespace CompositePattern.LeetCode
{
    public class Solution01
    {
        public bool DublicateNumber(int[] numbers)
        {
            Dictionary<int,int> nums = new Dictionary<int,int>();
            for(int i = 0;  i < numbers.Length; i++)
            {
                if(nums.ContainsKey(numbers[i]))
                {
                    return true;
                }
                else
                {
                    nums.Add(numbers[i], i);
                }
            }
            return false;
        }
    }
}