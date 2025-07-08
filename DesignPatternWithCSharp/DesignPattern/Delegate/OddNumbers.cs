namespace DesignPattern.Delegate
{
    public class OddNumbers
    {
        public IEnumerable<int> GenerateOdd(int max)
        {
            for (int i = 1; i <= max; i+=2)
            {
                yield return i;
            }
        }
    }
}