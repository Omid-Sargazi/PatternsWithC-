using Domain.Entities;
namespace Application.Interfaces
{
    public interface IUserRepository
    {
        void Save(User user);
        bool EmailExists(string email);
        User? Authenticate(string email, string password);
    }
}