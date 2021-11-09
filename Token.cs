﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloUWP
{
    public class Token
    {
        public string access_token { get; set; }
        public string refresh_token { get; set; }
        public string account_id { get; set; }
        public DateTime expire { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public int status { get; set; }
    }
}
