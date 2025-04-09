namespace CompositePattern.APIGetAway
{
    public class Gateway
    {
        private IAuthentication _authentication;
        private IService _service;
        public Gateway(IAuthentication authentication, IService service)
        {
            _authentication = authentication;
            _service = service;
        }
        
        public string ProcessRequest(string serviceType)
        {
            if(_authentication.Validate())
            {
                return $"درخواست {_service.Process()} با {_authentication.GetAuthType()} پردازش شد";
            }
            return "خطا در اعتبار سنجی";
        }
    }
}