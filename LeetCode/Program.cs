using LeetCode.BridgePattern;
using LeetCode.DecoratorPattern;
using LeetCode.Delegate;
using LeetCode.Problems01;

namespace LeetCode
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string s = "abc";
            string s2 = "aabbcd";
            char c = 'b';
            Solution solution = new Solution();
            Console.WriteLine(solution.HasDuplicate(s));
            Console.WriteLine(solution.HasDuplicate(s2));
            Console.WriteLine(solution.HasCharacter(s, c));
            Console.WriteLine(solution.LastIndexOfChar(s2, c));

            ICoffee myCoffee = new SimpleCoffee();
            Console.WriteLine(myCoffee.GetDescription());
            Console.WriteLine(myCoffee.GetPrice());
            myCoffee = new Milk(myCoffee);
            Console.WriteLine(myCoffee.GetDescription());

            myCoffee = new Cream(myCoffee);
            Console.WriteLine(myCoffee.GetDescription());

            ICoffee espresso = new Espresso();
            espresso = new Milk(espresso);
            Console.WriteLine(espresso.GetDescription());

            IDrawingTool pencil = new Pencil();
            IDrawingTool brush = new Brush();

            Shape circle = new Shape(pencil) { Name = "Circle" };
            Shape squae = new Shape(brush) { Name = "Square" };

            ClientRunOrder.Run();

            RunDelegate.Run();
            
        }
    }
}