namespace CompositePattern.APIGetAway
{
    public class OAuth : IAuthentication
    {
        public string GetAuthType()
        {
            return "OAth";
        }

        public bool Validate()
        {
            return true;
        }
    }
}