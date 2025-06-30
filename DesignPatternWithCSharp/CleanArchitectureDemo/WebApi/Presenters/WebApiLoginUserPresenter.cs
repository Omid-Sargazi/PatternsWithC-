using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Presenters
{
    public class WebApiLoginUserPresenter : ILoginUserOutput
    {
        public IActionResult Result { get; private set; } = new StatusCodeResult(500);
        public void Presenter(LoginUserResponse response)
        {
            Result = response.Success ? new OkObjectResult(response) : new UnauthorizedObjectResult(response);
        }
    }
}