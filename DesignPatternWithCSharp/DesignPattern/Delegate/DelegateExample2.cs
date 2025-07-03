namespace DesignPattern.Delegate
{
    public class DelegateProblem02
    {
        public delegate void Notify();

        public Notify ProcessCompleted;

        public void StartProcess()
        {
            Console.WriteLine("Processing started...");
            Console.WriteLine("Processing finished.");
            ProcessCompleted?.Invoke();

        }
    }
}