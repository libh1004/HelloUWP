using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloUWP
{
    public class ConfigurationSong
    {
        public static string ApiBaseUri = "https://music-i-like.herokuapp.com";
        public static string ApiPostPath = "/api/v1/songs";
        public static string ApiPostMine = "/api/v1/songs/mine";
        public static string ApiDataType = "application/json";
    }
}
