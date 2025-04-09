namespace CompositePattern.APIGetAway
{
    public class Gateway
    {
        private IAuthentication _authentication;
        public Gateway(IAuthentication authentication)
        {
            _authentication = authentication;
        }
        
        public string ProcessRequest(string serviceType)
        {
            if(_authentication.Validate())
            {
                return $"درخواست {serviceType} با {_authentication.GetAuthType()} پردازش شد";
            }
            return "خطا در اعتبار سنجی";
        }
    }
}