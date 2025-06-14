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
}