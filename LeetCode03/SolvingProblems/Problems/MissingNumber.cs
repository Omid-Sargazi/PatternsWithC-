namespace SolvingProblems.Problems
{
    public class MissingNumber
    {
        public int FindMissNumber(int[] nums)
        {
            var length = nums.Length;
            var sum = (length * (length + 1)) / 2;
            var sumNums = 0;
            foreach (var num in nums)
            {
                sumNums += num;
            }
            var missNum = sum - sumNums;
            return missNum;
        }
    }
}