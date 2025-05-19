namespace SolvingProblems.Problems
{
    public class NumberOf1Bits
    {
        public int NumberOfoneBit(int num)
        {
            int result = 0;
            while (num !=0)
            {
             if (num % 2 == 1)
            {
                result++;
            }
                num /= 2;
           }
            return result;
        }
    }
}