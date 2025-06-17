namespace AdvantureWorksDatabse02.CleanArchitecture
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public interface IUserService
    {
        User GetUserById(int id);
    }

    public class UserController
    {
        private readonly IUserService _userServide;
        
        public UserController(IUserService userService){
            _userService = userService;
        }
    }
}