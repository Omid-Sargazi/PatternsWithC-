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

        public RegisterUserUseCasee(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public RegisterUserResponse Execute(RegisterUserRequest request)
        {
            if (_userRepository.EmailExists(request.Email))
            {
                return new RegisterUserResponse { Success = false, Message = "Email already exists" };
            }

            var user = new User(request.Email, request.Password);

            if (!user.IsValid())
            {
                return new RegisterUserResponse { Success = false, Message = "Invalid data" };
            }

            _userRepository.Save(user);

            return new RegisterUserResponse { Success = true, Message = "User registered!" };
        }
    }
}