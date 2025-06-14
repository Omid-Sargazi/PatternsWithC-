namespace AdvantureWorksDatabse02.CommandPattern
{
    public interface ICommand01
    {
        void Execute();
    }

    public class SimpleCommand : ICommand01
    {
        private string _payload = string.Empty;
        public SimpleCommand(string payload)
        {
            _payload = payload;
        }
        public void Execute()
        {
            Console.WriteLine($"SimpleCommand: See, I can do simple things like printing ({this._payload})");
        }
    }

    public class ComplexCommand : ICommand01
    {
        private string _a;
        private string _b;
        private Receiver _receiver;
        public ComplexCommand(Receiver receiver, string a, string b)
        {
            _a = a;
            _b = b;
            _receiver = receiver;

        }
        public void Execute()
        {
            throw new NotImplementedException();
        }
    }


    public class Receiver
    {
        public void DoSomething(string a)
        {
            Console.WriteLine($"Receiver: Working on ({a}.)");
        }

        public void DoSomethingElse(string b)
        {
            Console.WriteLine($"Receiver: Also working on ({b}.)");
        }
    }

}