using Application.DTOs;
using Application.Interfaces;
using Application.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly RegisterUserUseCase _registerUserUseCase;

        public UserController(IUserRepository userRepository)
        {
            _registerUserUseCase = new RegisterUserUseCase(userRepository);
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterUserRequest request)
        {
            var result = _registerUserUseCase.Execute(request);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
       

    }
}