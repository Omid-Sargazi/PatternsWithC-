using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Presenters
{
    public class WebApiRegisterUserPresenter : IRegisterUserOutput
    {
        public IActionResult Result { get; private set; } = new StatusCodeResult(500);
        public void Present(RegisterUserResponse response)
        {
            Result = response.Success
            ? new OkObjectResult(response)
            : new BadRequestObjectResult(response);
        }
    }
}