namespace Patterns.RegisterSchool
{
    public class NotSameAsUsernameStrategy : IPasswordValidationStrategy
    {
        public string ErorMessage => "رمز عبور نباید با نام کاربری یکسان باشد.";

        public bool IsValid(string password, string userName)
        {
            return password != userName;
        }
    }
}