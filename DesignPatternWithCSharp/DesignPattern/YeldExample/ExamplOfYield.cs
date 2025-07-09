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
        } 


        static IEnumerable<int> GetNumbers()
        {
            yield return 1;
            yield return 2;
            yield return 3;
        }
    }
}