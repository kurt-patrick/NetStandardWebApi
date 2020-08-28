using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Routing_Direct_Routes.Controllers
{
    public class OptionalController : ApiController
    {

        /// <summary>
        /// Result of calls
        /// {{base_url}}/api/optional/1,2 = "skip has value 1, take has value 2"
        /// {{base_url}}/api/optional/a,2 = "skip not provided, take has value 2"
        /// {{base_url}}/api/optional/1,z = "skip has value 1, take not provided"
        /// {{base_url}}/api/optional/a,b = "skip not provided, take not provided"
        /// {{base_url}}/api/optional/a,1,1,1,1 = "skip not provided, take has value 1"
        /// {{base_url}}/api/optional/a = returns 404
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/optional/{skip?},{take?}")]
        public string GetWithOptionalRouteValues(int? skip = null, int? take = null)
        {
            return string.Format("skip {0}, take {1}", Output(skip), Output(take));
        }

        private static string Output(int? value)
        {
            return value.HasValue ? $"has value {value.Value}" : "not provided";
        }

    }
}
