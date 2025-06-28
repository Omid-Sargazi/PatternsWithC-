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
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterUserRequest request)
        {
            var useCase = new RegisterUserUseCase(_userRepository);
            var result = useCase.Execute(request);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}