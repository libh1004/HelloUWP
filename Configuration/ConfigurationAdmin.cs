using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloUWP.Configuration
{
    public class ConfigurationAdmin
    {
        public static string ApiBaseUri = "https://music-i-like.herokuapp.com";
        public static string ApiGetSongs = "/admin/songs";
        public static string ApiGetAccounts = "/admin/accounts";
        public static string ApiDataType = "application/json";
    }
}
