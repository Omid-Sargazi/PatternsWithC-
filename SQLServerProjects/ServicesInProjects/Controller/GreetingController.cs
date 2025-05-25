using Microsoft.AspNetCore.Mvc;
using ServicesInProjects.Services;

namespace ServicesInProjects.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class GreetingController : ControllerBase
    {
        private readonly IGreetingService _greetingService;
        public GreetingController(IGreetingService greetingService)
        {
            _greetingService = greetingService;
        }

        [HttpGet]
        public IActionResult Get()
        {
           try
           {
             var message = _greetingService.GetGreeting();
            return Ok(message);
           }
           catch (Exception)
           {
                Console.WriteLine("Occured a message");
            throw;
           }
        }
    }
}