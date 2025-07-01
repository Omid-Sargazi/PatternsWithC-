namespace DesignPattern.Delegate
{
    public delegate void Notify();
    public class ProcessBusinessLogic
    {
        public Notify ProcessCompleted;
        public void StartProcess()
        {
            Console.WriteLine("Processing started...");
            Console.WriteLine("Processing finished.");
            ProcessCompleted?.Invoke();
        }
    }
}