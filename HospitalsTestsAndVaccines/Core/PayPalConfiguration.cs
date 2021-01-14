using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HospitalsTestsAndVaccines.Core
{
    public static class PayPalConfiguration
    {
        //Variables for storing the clientID and clientSecret key  
        public readonly static string ClientId;
        public readonly static string ClientSecret;
        //Constructor  
        static PayPalConfiguration()
        {
            var config = GetConfig();
            ClientId = "AUT9LXbHePvLesnMVil91mlilZ8bQZzg0h5MMnRodTVUuEdOjmE7vpGTT2xzmR_zcydhsTLpe2cphsGt";
            ClientSecret = "EGUKbv7DI1xXXsqocsZCV2f5ffueU7euaZe5e9UP2Ifhe2hq6HN9cxxL6FyXeb1sxfEntQClnB1sZBXK";
        }
        // getting properties from the web.config  
        public static Dictionary<string, string> GetConfig()
        {
            return PayPal.Api.ConfigManager.Instance.GetProperties();
        }
        private static string GetAccessToken()
        {
            // getting accesstocken from paypal  
            string accessToken = new OAuthTokenCredential(ClientId, ClientSecret, GetConfig()).GetAccessToken();
            return accessToken;
        }
        public static APIContext GetAPIContext()
        {
            // return apicontext object by invoking it with the accesstoken  
            APIContext apiContext = new APIContext(GetAccessToken());
            apiContext.Config = GetConfig();
            return apiContext;
        }
    }
}