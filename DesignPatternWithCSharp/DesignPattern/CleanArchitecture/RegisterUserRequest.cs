namespace DesignPattern.CleanArchitecture
{
    public class RegisterUserRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class RegisterUserResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }

    public interface IRegisterUserInput
    {
        RegisterUserResponse Execute(RegisterUserRequest request);
    }

    public class RegisterUserUseCasee : IRegisterUserInput
    {
        private readonly IUserRepository _userRepository;
        private readonly IRegisterUserOutput _presenter;

        public RegisterUserUseCasee(IUserRepository userRepository,
        IRegisterUserOutput presenter)
        {
            _userRepository = userRepository;
            _presenter = presenter;
        }
        public RegisterUserResponse Execute(RegisterUserRequest request)
        {
            var response = new RegisterUserResponse();
            if (_userRepository.EmailExists(request.Email))
            {
                response.Success = false;
                response.Message = "Email exists";
                _presenter.Present(response);
                return response;
                // return new RegisterUserResponse { Success = false, Message = "Email already exists" };
            }

            var user = new User(request.Email, request.Password);

            if (!user.IsValid())
            {
                response.Success = false;
                response.Message = "Invalid data.";
                _presenter.Present(response);
                return response;
                // return new RegisterUserResponse { Success = false, Message = "Invalid data" };
            }

            _userRepository.Save(user);
            response.Success = true;
            response.Message = "User registered!";
            _presenter.Present(response);

            return new RegisterUserResponse { Success = true, Message = "User registered!" };
        }
    }

    public interface IRegisterUserOutput
    {
        void Present(RegisterUserResponse response);
    }

    public class ConsolePresenter : IRegisterUserOutput
    {
        public void Present(RegisterUserResponse response)
        {
            Console.WriteLine(response.Success ? "✅ " + response.Message : "❌ " + response.Message);
        }
    }
}