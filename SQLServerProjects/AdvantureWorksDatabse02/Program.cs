namespace AdvantureWorksDatabse02
{
    
    // See https://aka.ms/new-console-template for more information
public delegate int Calculator(int a, int b);
public class Program
{
    public static  void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Calculator calc = Add;
        int result = calc(5, 3);
        Console.WriteLine(result);
    }

    public static int Add(int x, int y)
    {
        int sum = x + y;
        Console.WriteLine($"Add:{sum}");
        return sum;
    }
}
}