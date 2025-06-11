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

    public interface ILoggerService
    {
        void Log(string msg);
    }

    public class LoggerService : ILoggerService
    {
        public void Log(string msg)
        {
            Console.WriteLine($"[Log] {msg}");
        }
    }

    public class BusinessService
    {
        private readonly ILoggerService _logger;
        public BusinessService(ILoggerService logger) => _logger = logger;
        public void Run() => _logger.Log("Business logic executed");
    }

    public interface IAppInfoService
    {
        string GetAppName();
    }

    public class AppInfoService : IAppInfoService
    {
        private readonly IConfiguration _config;
        public AppInfoService(IConfiguration config) => _config = config;
        public string GetAppName()
        {
            return _config["AppName"];
        }
    }

    public interface IGitHubService
    {
        Task<string> GetReposAsync();
    }

    public class GitHubService : IGitHubService
    {
        private readonly HttpClient _httpClient;
        public GitHubService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<string> GetReposAsync()
        {
            var response = await _httpClient.GetStringAsync("https://api.github.com/users/octocat/repos");
            return response;
        }
    }
}