using Application.DTOs;
using Application.Interfaces;
using Application.UseCases;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;
using WebApi.Presenters;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly WebApiRegisterUserPresenter _presenter;

        public UserController(IUserRepository userRepository, IRegisterUserOutput presenter)
        {
            _userRepository = userRepository;
            _presenter = (WebApiRegisterUserPresenter)presenter;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterUserRequest request)
        {

            var useCase = new RegisterUserUseCase(_userRepository, _presenter);

            useCase.Execute(request);
            return _presenter.Result ?? StatusCode(500, "Unexpected error: Presenter returned null.");
        }


        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginUserRequest request)
        {
            var loginPresenter = new WebApiLoginUserPresenter();
            var loginUseCase = new LoginUserUseCase(_userRepository, loginPresenter);

            loginUseCase.Execute(request);

            return loginPresenter.Result ?? StatusCode(500, "Unexpected error.");
        }


        [HttpGet("boom")]
        public IActionResult Boom()
        {
            throw new Exception("this is a test exception");
        }

        [HttpGet("datetime")]
        public IActionResult GetDate()
        {
            return Ok(DateTime.Now.ToString("D"));
        }
       
       

    }
}