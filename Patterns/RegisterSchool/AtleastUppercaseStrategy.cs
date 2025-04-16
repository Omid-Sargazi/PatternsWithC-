namespace Patterns.RegisterSchool
{
    public class AtleastUppercaseStrategy : IPasswordValidationStrategy
    {
        public string ErorMessage => "رمز عبور باید حداقل یک حرف بزرگ داشته باشد.";

        public bool IsValid(string password, string userName)
        {
            return password.Any(char.IsUpper);
        }
    }
}