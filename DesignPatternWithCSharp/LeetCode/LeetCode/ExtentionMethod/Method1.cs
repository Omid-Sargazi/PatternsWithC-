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

    public static class StringExtensions
    {
        public static int ToIntOrDefault(this string input, int defaultValue = 0)
        {
            return int.TryParse(input, out int result) ? result : defaultValue;
        }
    }

    public static class MathExtensions
    {
        public static bool Divide(int a, int b, out int quotient, out int reminder)
        {
            if (b == 0)
            {
                quotient = 0;
                reminder = 0;
                return false;
            }
            quotient = a / b;
            reminder = a % b;
            return true;
        }
    }

    public static class StringExtensionss
    {
        public static bool TryParseDate(this string dateString, out DateTime result)
        {
            return DateTime.TryParse(dateString, out result);
        }
    }

    public static class ListExtensions
    {
        public static void GetStatus(this List<int> numbers, out int sum, out int count)
        {
            sum = numbers.Sum();
            count = numbers.Count();
        }
    }

    public static class StringExtensions2
    {
        public static bool FindWord(this string text, string word, out int position)
        {
            position = text.IndexOf(word);
            return position >= 0;
        }
    }

    public static class ObjectExtensions
    {
        public static bool EnsureNotNull<T>(this T input, out T result) where T : class, new()
        {
            result = input ?? new T();
            return input != null;
        }
    }
}