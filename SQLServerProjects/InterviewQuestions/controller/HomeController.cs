using System.Threading.Tasks;
using InterviewQuestions.Day01;
using Microsoft.AspNetCore.Mvc;

namespace InterviewQuestions.controller
{
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        private readonly IGreetingService _greating;
        private readonly ITimeService _time;
        private readonly IAppInfoService _appInfo;
        private readonly IGitHubService _gitHub;
        public HomeController(IGreetingService greeting,
        ITimeService time, IAppInfoService appInfo,
        IGitHubService gitHub
        )
        {
            _greating = greeting;
            _time = time;
            _appInfo = appInfo;
            _gitHub = gitHub;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var msg = _greating.GetMessage();
            return Content(msg);
        }
        [HttpGet("time")]
        public IActionResult Time()
        {
            var time = _time.GetCurrentTime();
            return Content(time);
        }
        [HttpGet("config")]
        public IActionResult Config()
        {
            var appInfo = _appInfo.GetAppName();
            return Content(appInfo);
        }

        [HttpGet("gitapi")]
        public async Task<IActionResult> GitApi()
        {
            var gitApi =  await _gitHub.GetReposAsync();
            return Content(gitApi);
        }
    }
}