namespace Patterns.RegisterSchool
{
    public interface IPasswordValidationStrategy 
    {
        bool IsValid(string password, string userName);
        string ErorMessage {get;}
    }
}