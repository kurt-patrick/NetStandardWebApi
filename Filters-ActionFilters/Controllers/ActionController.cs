using Filters_ActionFilters.Filters;
using Filters_ActionFilters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Filters_ActionFilters.Controllers
{
    public class ActionController : ApiController
    {
        // GET: api/Action
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Action/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Action
        [ValidateNullModel()]
        [ValidateModelState()]
        public void Post(Item item)
        {
        }

        // PUT: api/Action/5
        [ValidateNullModel()]
        [ValidateModelState()]
        public void Put(int id, Item item)
        {
        }

        // DELETE: api/Action/5
        public void Delete(int id)
        {
        }
    }
}
