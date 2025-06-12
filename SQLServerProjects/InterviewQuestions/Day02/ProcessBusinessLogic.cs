using InterviewQuestions.Day01;

namespace InterviewQuestions.Day02
{
    public class ProcessBusinessLogic : IProcessNotifier, IDisposable
    {
        public event Action ProcessCompleted;

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void StartProcess()
        {
             Console.WriteLine("Processing started...");
            // پردازش‌های مورد نظر
            Console.WriteLine("Processing finished.");
            ProcessCompleted?.Invoke();
        }
    }
}