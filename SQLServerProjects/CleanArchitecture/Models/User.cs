namespace CleanArchitecture.Models
{
    public class User
    {
        public int Id { get; private set; }
        public string Email { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public bool IsValidEmail(string Email)
        {
            if (string.IsNullOrEmpty(Email)) return false;
            return Email.Contains("@") && Email.Length > 5;
        }

        // Domain Rules
        public void ChangeEmail(string newEmail)
        {
            if (!IsValidEmail(newEmail))
                throw new InvalidOperationException("ایمیل نامعتبر است");

            Email = newEmail;
        }

        public static User Create(string email)
        {
            var user = new User
            {
                Email = email,
                CreatedAt = DateTime.UtcNow
            };

            if (!user.IsValidEmail(email))
                throw new ArgumentException("ایمیل نامعتبر");

            return user;
        }
    }

    public class UserEmailChanged
    {
        public int UserId { get; set; }
        public string OldEmail { get; set; }
        public string NewEmail { get; set; }
        public DateTime ChangedAt { get; set; }
    }

    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);
        Task<User> GetByEmailAsync(string email);
        Task SaveAsync(User user);
        Task<bool> ExistsAsync(int id);
    }

    public interface IEmailService
    {
        Task SendWelcomeEmailAsync(string email);
    }

    public interface ILogger
    {
        void LogInfo(string message);
        void LogError(string message, Exception ex);
    }
}