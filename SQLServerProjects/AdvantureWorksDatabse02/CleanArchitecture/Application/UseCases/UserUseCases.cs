namespace AdvantureWorksDatabse02.CleanArchitecture.Application.UseCases
{
    public class UserUseCases
    {
        private readonly IUserRepository _userRepository;
        public UserUseCases(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserDto?> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if(user==null) return null;

            return new UserDto
            {
                Id=user.id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                FullName = 
            };
        }
    }
}