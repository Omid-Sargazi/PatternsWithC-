namespace Patterns.RegisterSchool
{
    public class PasswordStrengthValidationStrategy : IUserValidationStrategy
    {
        public string ErrorMessage => "Password must be at least 6 characters.";

        public bool IsValid(User user)
        {
            return user.Password.Length >= 6;
        }
    }
}