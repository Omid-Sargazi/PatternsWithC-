namespace Patterns.RegisterSchool
{
    public class ContainsNumberStrategy : IPasswordValidationStrategy
    {
        public string ErorMessage => "رمز عبور باید حداقل شامل یک عدد باشد";

        public bool IsValid(string password, string userName)
        {
            return password.Any(char.IsDigit);
        }
    }
}