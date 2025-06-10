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
        public HomeController(IGreetingService greeting, ITimeService time, IAppInfoService appInfo)
        {
            _greating = greeting;
            _time = time;
            _appInfo = appInfo;
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
    }
}