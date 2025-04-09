namespace LeetCode.Problems01
{
    public class Solution
    {
        public bool HasCharacter(string s, char c)
        {
            for(int i=0; i<s.Length;i++)
            {
                if(s[i]==c)
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasDuplicate(string s)
        {
            for(int i = 0; i<s.Length; i++)
            {
                for(int j=i+1; j<s.Length; j++)
                {
                    if(s[i]==s[j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public int LastIndexOfChar(string s, char c)
        {
            Dictionary<char, int> charMap = new Dictionary<char, int>();
            for(int i = 0; i<s.Length; i++)
            {
                charMap[s[i]] = i;
            }
            return charMap.ContainsKey(c) ? charMap[c] : -1;
        }

        public int LongestPrefixWithoutRepeat(string s)
        {
            Dictionary<char, int> charMap = new Dictionary<char, int>();
            int length = 0;
            for(int i = 0; i<s.Length; i++)
            {
                if(charMap.ContainsKey(s[i]))
                {
                    break;
                }
                charMap[s[i]] = i;
                length = i+1;
            }
            return length;
        }

        public int LengthOfLongestSubstring(string s)
        {
            if(string.IsNullOrEmpty(s))
            {
                return 0;
            }

            Dictionary<char, int> charMap = new Dictionary<char, int>();
            int maxLength = 0;
            int start = 0;
            for(int end = 0; end <= s.Length ; end++)
            {
                if(charMap.ContainsKey(s[end]) && charMap[s[end]]>=start)
                {
                    start = charMap[s[end]] + 1;
                }
                charMap[s[end]] = end;
                int currentLength = end - start + 1;
                maxLength = Math.Max(maxLength, currentLength);
            }
            return maxLength;
        }
    }
}