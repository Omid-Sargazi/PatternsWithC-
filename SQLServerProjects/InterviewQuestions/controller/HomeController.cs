using InterviewQuestions.Day01;
using Microsoft.AspNetCore.Mvc;

namespace InterviewQuestions.controller
{
   [Route("api/[controller]")]
    public class HomeController : Controller
    {
        private readonly IGreetingService _greating;
        public HomeController(IGreetingService greeting)
        {
            _greating = greeting;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var msg = _greating.GetMessage();
            return Content(msg);
        }
    }
}