namespace DesignPattern.LeetCode
{
    public class SumTwoNumber
    {
        private Dictionary<int, int> map = new Dictionary<int, int>();
        public int[] RunSumTwoNumber(int[] numbers, int target)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                int complete = target - numbers[i];
                if (!map.ContainsKey(numbers[i]))
                {
                    map[numbers[i]] = i;
                }
                if (map.ContainsKey(complete))
                {
                    return new int[] { i, map[complete] };
                }
            }
            return new int[]{};
        }
    }
}