namespace Patterns.RegisterSchool
{
    public interface IUserValidationStrategy
    {
        bool IsValid(User user);
        string ErrorMessage {get;}
    }
}