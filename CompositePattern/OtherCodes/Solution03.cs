namespace CompositePattern.OtherCodes
{
    public class Solution03
    {
        public int[] TwoLengthSum(string[] words, int target)
        {
            Dictionary<int, int> seenLengths = new Dictionary<int, int>();
           for(int i = 0 ; i<words.Length; i++)
           {
                int complete = target - words[i].Length;
                if(seenLengths.ContainsKey(complete))
                {
                    return new int[] {seenLengths[complete], i};
                }
            seenLengths[words[i].Length] = i;
           }
           }
        return new int[] {};
    }
}
