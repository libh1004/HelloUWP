using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloUWP.Configuration
{
    public class ConfigurationAccount
    {
        public static string ApiBaseUri = "https://music-i-like.herokuapp.com";
        public static string ApiBaseUriProfile = "https://music-i-like.herokuapp.com";
        public static string ApiPostPath = "/api/v1/accounts";
        public static string ApiLoginPath = "/api/v1/accounts/authentication";
        public static string ApiGetProfile = "/api/v1/accounts";
        public static string ApiDataType = "application/json";
    }
}
