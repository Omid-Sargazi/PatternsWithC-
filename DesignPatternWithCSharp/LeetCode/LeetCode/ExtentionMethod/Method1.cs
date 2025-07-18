namespace LeetCode.ExtentionMethod
{
    public static class ExtentionMethods
    {
        public static IEnumerable<int> GetEvents(this List<int> numbers)
        {
            return numbers.Where(x => x % 2 == 0);
        }
    }

    public static class Enumerable
    {
        public static IEnumerable<TSource> Wheree<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item))
                    yield return item;
            }
        }
    }
}