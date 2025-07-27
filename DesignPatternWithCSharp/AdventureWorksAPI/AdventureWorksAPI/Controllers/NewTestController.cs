using Microsoft.AspNetCore.Mvc;

namespace AdventureWorksAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NewTestController : ControllerBase
    {
        [HttpGet("exception")]
        public IActionResult Throw() => throw new Exception("Erorr Testing");

        [HttpGet("ok")]
        public IActionResult OkMessage() => Ok("all things is good");

        [HttpGet("ping")]
        public IActionResult Ping()
        {
            return Ok("Pong");
        }
    }
}