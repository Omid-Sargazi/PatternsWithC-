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

    public interface ITimeService
    {
        string GetCurrentTime();
    }

    public class TimeService : ITimeService
    {
        private readonly string _time = DateTime.Now.ToString();
        public string GetCurrentTime()
        {
            return _time;
        }
    }
}