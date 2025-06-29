using Application.DTOs;
using Application.Interfaces;

namespace WebApi.Presenters
{
    public class ConsoleRegisterUserPresenter : IRegisterUserOutput
    {
        public void Present(RegisterUserResponse response)
        {
            Console.WriteLine(response.Success?$"✅ {response.Message}":$" {response.Message}");
        }
    }
}