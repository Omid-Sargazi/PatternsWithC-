namespace LeetCode.Problem1
{
    public class CountUniqueElements
    {
        private HashSet<int> unique = new HashSet<int>();
        public int RunCountUniqueElements(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                unique.Add(nums[i]);
            }

            return unique.Count();
        }
    }

    public class FrequencyAnalyzer
    {
        private Dictionary<int, int> FrequesntMap = new Dictionary<int, int>();

        public (Dictionary<int, int> freqency, int uniqueCount) Analyze(int[] nums)
        {
            foreach (var num in nums)
            {
                if (FrequesntMap.ContainsKey(num))
                    FrequesntMap[num]++;
                else
                    FrequesntMap[num] = 1;
            }

            int uniqueCount = FrequesntMap.Values.Count(v => v == 1);
            return (FrequesntMap, uniqueCount);
        }
    }

    public class RemoveDuplicates
    {
        public int RunRemoveDuplicates(int[] nums)
        {
            if (nums.Length == 0)
                return 0;
            int i = 0;
            for (int j = 0; i < nums.Length; j++)
            {
                if (nums[j] != nums[i])
                {
                    i++;
                    nums[i] = nums[j];
                }
            }
            return i + 1;
        }
    }
}