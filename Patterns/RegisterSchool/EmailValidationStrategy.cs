namespace Patterns.RegisterSchool
{
    public class EmailValidationStrategy : IUserValidationStrategy
    {
        public string ErrorMessage => "Invalid email format.";

        public bool IsValid(User user)
        {
            return user.Email.Contains("@");
        }
    }
}