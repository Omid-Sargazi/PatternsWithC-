namespace AdvantureWorksDatabse02.CleanArchitecture.Domain.Interfaces
{
     public interface IUserRepository
    {
        Task<User?> GetByIdAsync(int id);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> CreateAsync(User user);
        Task<User> UpdateAsync(User user);
        Task<bool> DeleteAsync(int id);
        Task<User?> GetByEmailAsync(string email);
    }
}