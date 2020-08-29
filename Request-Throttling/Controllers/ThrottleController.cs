using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Request_Throttling.Controllers
{
    public class ThrottleController : ApiController
    {
        [Route("api/throttle")]
        public string GetAction()
        {
            return "hey hey";
        }
    }
}
