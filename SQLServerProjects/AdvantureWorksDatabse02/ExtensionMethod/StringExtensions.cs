using System.Reflection.Metadata;

namespace AdvantureWorksDatabse02.ExtensionMethod
{
    public static class StringExtensions
    {
        public static bool IsNumeric(this string str)
        {
            return int.TryParse(str, out _);
        }
    }

    public static class ListExtensions
    {
        public static void AddRange<T>(this List<T> list, params T[] items)
        {
            foreach (var item in items)
            {
                list.Add(item);
            }
        }

        public static List<T> RemoveDuplicates<T>(this List<T> list)
        {
            return list.Distinct().ToList();
        }

        public static bool IsNullOrEmpty<T>(this List<T> list)
        {
            return list == null || list.Count == 0;
        }
    }


}