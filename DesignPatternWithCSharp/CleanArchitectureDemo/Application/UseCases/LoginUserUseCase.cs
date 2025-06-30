using Application.DTOs;
using Application.Interfaces;

namespace Application.UseCases
{
    public class LoginUserUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly ILoginUserOutput _presenter;
        public LoginUserUseCase(IUserRepository userRepository, ILoginUserOutput presenter)
        {
            _userRepository = userRepository;
            _presenter = presenter;
        }

        public void Execute(LoginUserRequest request)
        {
            var resposne = new LoginUserResponse();
            var user = _userRepository.Authenticate(request.Email, request.Password);
            if (user == null)
            {
                resposne.Success = false;
                resposne.Message = "Invalid email or password.";
                _presenter.Presenter(resposne);
                return;
            }
            resposne.Success = true;
            resposne.Message = $"Welcome, {user.Email}";
            _presenter.Presenter(resposne);
        }
    }
}