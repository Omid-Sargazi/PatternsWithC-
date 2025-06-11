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

    public static class DateTimeExtensions
    {
        public static string ToPersianDate(this DateTime date)
        {
            var persianCalendar = new System.Globalization.PersianCalendar();
            var year = persianCalendar.GetYear(date);
            var month = persianCalendar.GetMonth(date);
            var day = persianCalendar.GetDayOfMonth(date);

            return $"{year}/{month:00}/{day:00}";
        }

        public static bool IsWeekend(this DateTime date)
        {
            return date.DayOfWeek == DayOfWeek.Friday ||
                date.DayOfWeek == DayOfWeek.Saturday;
        }

        public static DateTime StartOfWeek(this DateTime date)
        {
            int diff = (7 + (date.DayOfWeek - DayOfWeek.Saturday)) % 7;
            return date.AddDays(-1 * diff).Date;
        }
    }

    public static class NumericExtensions
    {
        public static bool IsPrime(this int number)
        {
            if (number < 2) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            for (int i = 3; i <= Math.Sqrt(number); i += 2)
            {
                if (number % i == 0) return false;
            }
            return true;
        }
    }

}