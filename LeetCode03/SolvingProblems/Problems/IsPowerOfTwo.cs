namespace SolvingProblems.Problems
{
    public class IsPowerOfTwo
    {
        public bool isPowerOf2(int num)
        {
            return num > 0 && (num & (num - 1)) == 0;
        }
    }
}