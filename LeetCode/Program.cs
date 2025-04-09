using LeetCode.Problems01;

namespace LeetCode
{
    public class Program
    {
        public static void Main(string[] args){
            Console.WriteLine("Hello, World!");
            string s = "abc";
            string s2 = "aabbcd";
            char c = 'b';
            Solution solution = new Solution();
            Console.WriteLine(solution.HasDuplicate(s));
            Console.WriteLine(solution.HasDuplicate(s2));
            Console.WriteLine(solution.HasCharacter(s, c));
            Console.WriteLine(solution.LastIndexOfChar(s2, c));
        }
    }
}