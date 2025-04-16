namespace Patterns.RegisterSchool
{
    public class MinimumLengthStrategy : IPasswordValidationStrategy
    {
        public string ErorMessage => "رمز عبور باید حداقل 8 کاراکتر باشد.";

        public bool IsValid(string password, string userName)
        {
            return password.Length >= 8;
        }
    }
}