using InterviewQuestions.Day01;
using Microsoft.AspNetCore.Mvc;

namespace InterviewQuestions.controller
{
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        private readonly IGreetingService _greating;
        private readonly ITimeService _time;
        public HomeController(IGreetingService greeting, ITimeService time)
        {
            _greating = greeting;
            _time = time;
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
    }
}