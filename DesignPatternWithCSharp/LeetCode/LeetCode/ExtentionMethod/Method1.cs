namespace LeetCode.ExtentionMethod
{
    public static class ExtentionMethods
    {
        public static IEnumerable<int> GetEvents(this List<int> numbers)
        {
            return numbers.Where(x => x % 2 == 0);
        }
    } 
}