using Application.DTOs;
using Application.Interfaces;

namespace Application.UseCases
{
    public class LoginUserUseCase
    {
        private readonly IUserRepository _userRepository;
        public LoginUserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public LoginUserResponse Execute(LoginUserRequest request)
        {
            var user = _userRepository.Authenticate(request.Email, request.Password);
            if (user == null)
            {
                return new LoginUserResponse
                {
                    Success = false,
                    Message = "Invalid email or password."
                };
            }
            return new LoginUserResponse
            {
                Success = true,
                Message = $"Welcome, {user.Email}",
            };
        }
    }
}