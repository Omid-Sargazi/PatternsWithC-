namespace AdvantureWorksDatabse02.CleanArchitecture
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool IsValidEmail()
        {
            return Email.Contains("@");
        }
    }
    public interface IUserRepository
    {
        User GetById(int id);
    }
    public class GetUserUseCase
    {
        private readonly IUserRepository _repository;

        public GetUserUseCase(IUserRepository userRepository)
        {
            _repository = repository;
        }

        public User Exexute(int id)
        {
            return _repository.GetById(id);
        }
    }

    public interface IUserService
    {
        User GetUserById(int id);
    }

    public class GetUserUseCase
    {
        
    }

    public class UserController
    {
        private readonly IUserService _userServide;
        
        public UserController(IUserService userService){
            _userService = userService;
        }
    }
}