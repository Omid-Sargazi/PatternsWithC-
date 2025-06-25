namespace DesignPattern.CleanArchitecture
{
    public class User
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public User(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public bool IsValid()
        {
            return Email.Contains("@") && Password.Length >= 6;
        }
    }

    public interface IUserRepository
    {
        void Save(User user);
        bool EmailExists(string email);
    }

    public class RegisterUserUseCase
    {
        private readonly IUserRepository _userRepository;
        public RegisterUserUseCase(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void Execute(string email, string password)
    {
        if (_userRepository.EmailExists(email))
            throw new Exception("Email already registered!");

        var user = new User(email, password);

        if (!user.IsValid())
            throw new Exception("Invalid user data!");

        _userRepository.Save(user);
        Console.WriteLine("✅ User registered successfully.");
    }
    }
}