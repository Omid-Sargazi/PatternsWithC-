namespace InterviewQuestions.Day01
{
    public interface IGreetingService
    {
        string GetMessage();
    }

    public class GreetingService : IGreetingService
    {
        public string GetMessage()
        {
            return "Hello from DI";
        }
    }
}