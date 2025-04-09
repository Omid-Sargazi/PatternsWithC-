namespace CompositePattern.APIGetAway.WithoutBridgePattern
{
    public class Gateway
    {
       public string ProcessRequest(string authType, string servicesType)
       {
            if(authType == "OAth"&& servicesType == "Rest")
                return "درخواست REST با OAuth پردازش شد";
            if(authType == "JWt" && servicesType == "GraphQL")
                return "درخواست GraphQL با JWT پردازش شد";
            if(authType == "APIKey"&& servicesType=="gRPC")
                return "درخواست gRPC با API Key پردازش شد";
            return "Errro";
       }
    }
}