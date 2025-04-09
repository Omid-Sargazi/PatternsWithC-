using System.Reflection.Metadata.Ecma335;

namespace CompositePattern.OtherCodes
{
    public class Soulution05
    {
       public int LengthOfLongestSubstring(string s)
       {
            if(string.IsNullOrEmpty(s))
            {
                return 0;
            }
            int maxLength = 0;
            for(int i = 0; i < s.Length; i++)
            {
                for(int j = i; j < s.Length; j++)
                {
                    string substring = s.Substring(i, j-i +1);
                    if(IsUnique(substring))
                    {
                        if(substring.Length > maxLength)
                            maxLength = substring.Length;
                    }
                }
            }
            return maxLength;
       }

       private bool IsUnique(string str)
       {
            for(int k = 0; k<str.Length; k++)
            {
                for(int m = k+1; m< str.Length; m++)
                {
                    if(str[k]==str[m]) return false;
                }
            }
            return true;
       }
    }
}