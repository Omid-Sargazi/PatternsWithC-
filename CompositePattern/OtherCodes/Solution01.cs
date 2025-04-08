namespace CompositePattern.Pattern01
{
    public class Solution01
    {
       public  int[] TwoSum(int[] sums, int targer)
       {
        for(int i=0; i<sums.Length; i++)
        {
            for(int j = i+1; j<sums.Length; j++)
            {
                if(sums[i]+sums[j] == targer)
                {
                    return new int[] {i,j};
                }
            }
        }
                return new int[] {};
       }
    }
}