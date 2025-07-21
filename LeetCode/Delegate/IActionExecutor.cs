namespace LeetCode.Delegate
{
    public interface IActionExecutor
    {
        void Execute(string input, Action<string> action);
    }

    public class SimpleExecutor : IActionExecutor
    {
        public void Execute(string input, Action<string> action)
        {
            Console.WriteLine($"Executing");
            action(input);
        }
    }

    public class RunDelegate
    {
        public static void Run()
        {
            var executer = new SimpleExecutor();
            executer.Execute("Hiii", s => Console.WriteLine($"{s.ToLower()}"));
            executer.Execute("1234", s => Console.WriteLine($"Length: {s.Length}"));
            
        }
    }
}