using Application.DTOs;

namespace Application.Interfaces
{
    public interface ILoginUserOutput
    {
        void Presenter(LoginUserResponse response);
    }
}