using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Request_Throttling.Models
{
    public class User
    {
        public string Identifier { get; set; }
        public long RateLimit { get; set; } = 1;
    }
}