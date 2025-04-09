namespace CompositePattern.OtherCodes
{
    public class Solution06
    {
        public int LengthOfLongestSubstring(string s)
        {
            if(string.IsNullOrEmpty(s)) return 0;

            Dictionary<char, int> charMap = new Dictionary<char, int>();
            int maxLength = 0;
            int start = 0;
            for(int end = 0; end<s.Length; end++)
            {
                if(charMap.ContainsKey(s[end]) && charMap[s[end]]>=start)
                {
                    start = charMap[s[end]] + 1;
                }
                charMap[s[end]] = end;
                int currentLength = end - start + 1;

            }
            return Math.Max(maxLength,  start + 1);
        }
    }
}