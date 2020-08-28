using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Routing_Direct_Routes.Controllers
{
    public class DefaultsController : ApiController
    {
        /// <summary>
        /// Calls that would apply the default value
        /// {{base_url}}/api/defaults/onroute
        /// {{base_url}}/api/defaults/onroute/
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/defaults/onroute/{id:int=23}")]
        public string GetActionWithDefaultValueOnTheRoute(int id)
        {
            return id.ToString("0000");
        }

        /// <summary>
        /// Calls that would apply the default value
        /// {{base_url}}/api/defaults/onaction/a
        /// In the case above, as the letter is not a number the default is applied
        /// NOTE: The following cases do not apply a default, and instead, an error is returned
        /// {{base_url}}/api/defaults/onroute
        /// {{base_url}}/api/defaults/onroute/
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/defaults/onaction/{id}")]
        public string GetActionWithDefaultValueOnTheAction(int id = 45)
        {
            return id.ToString("0000");
        }

    }
}
