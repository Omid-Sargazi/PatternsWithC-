namespace CompositePattern.APIGetAway
{
    public class JWT : IAuthentication
    {
        public string GetAuthType()
        {
            return "JWT";
        }

        public bool Validate()
        {
            return true;
        }
    }
}