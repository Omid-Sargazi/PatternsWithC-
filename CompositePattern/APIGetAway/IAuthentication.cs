namespace CompositePattern.APIGetAway
{
    public interface IAuthentication
    {
        bool Validate();
        string GetAuthType();
    }
}