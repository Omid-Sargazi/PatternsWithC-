namespace AdvantureWorksDatabse02.Delegate
{
    public delegate void Notify();
    public class ProcessBusinessLogic
    {
        public Notify ProcessCompleted;

        public void StartProcess()
        {
            Console.WriteLine("Processing started...");
            // کارهای مختلف
            Console.WriteLine("Processing finished.");

            ProcessCompleted?.Invoke();
        }

        static void ShowMessage()
    {
        Console.WriteLine("Process Completed Successfully!");
    }
    }
}