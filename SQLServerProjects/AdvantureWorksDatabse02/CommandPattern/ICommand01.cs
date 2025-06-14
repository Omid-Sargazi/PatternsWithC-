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
            Console.WriteLine("ComplexCommand: Complex stuff should be done by a receiver object.");
            _receiver.DoSomething(a);
            _receiver.DoSomethingElse(b);
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


     class Invoker
    {
        private ICommand01 _onStart;

        private ICommand01 _onFinish;

        // Initialize commands.
        public void SetOnStart(ICommand01 command)
        {
            this._onStart = command;
        }

        public void SetOnFinish(ICommand01 command)
        {
            this._onFinish = command;
        }


}