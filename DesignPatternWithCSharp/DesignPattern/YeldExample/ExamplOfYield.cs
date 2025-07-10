namespace DesignPattern.YeldExample
{
    public class SimpleYieldExample
    {

        public static void Run()
        {
            foreach (var item in GetNumbers())
            {
                Console.WriteLine($"{item}: Yileld");
            }

            foreach (var item in GetEventNumber(10))
            {
                Console.WriteLine($"{item} : event number by Yield");
            }
        }


        static IEnumerable<int> GetNumbers()
        {
            yield return 1;
            yield return 2;
            yield return 3;
        }

        static IEnumerable<int> GetEventNumber(int max)
        {
            for (int i = 0; i <= max; i+=2)
            {
                yield return i;
            }
        }
    }
}