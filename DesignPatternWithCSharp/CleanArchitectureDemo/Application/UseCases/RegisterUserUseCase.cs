using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;

namespace Application.UseCases
{
    public class RegisterUserUseCase
    {
        private readonly IUserRepository _userRepository;
        private readonly IRegisterUserOutput _presenter;
        public RegisterUserUseCase(IUserRepository userRepository
        , IRegisterUserOutput presenter)
        {
            _userRepository = userRepository;
            _presenter = presenter;
        }

        public void Execute(RegisterUserRequest request)
        {

            var response = new RegisterUserResponse();
            if (request == null)
            {
                response.Success = false;
                response.Message = "Request is null";
                _presenter.Present(response);
                return;
            }
            
            
            if (_userRepository.EmailExists(request.Email))
            {
                response.Success = false;
                response.Message = "Email already registered!";
                _presenter.Present(response);
                return;
            }

            var user = new User(request.Email, request.Password);
            if (!user.IsValid())
            {
                response.Success = false;
                response.Message = "Invalid user data!";
                _presenter.Present(response);
                return;
            }

            _userRepository.Save(user);
            response.Success = true;
            response.Message = "User registered successfully!";
            _presenter.Present(response);
        }
    }
}