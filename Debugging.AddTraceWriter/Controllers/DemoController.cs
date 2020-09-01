using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Tracing;

namespace Debugging.AddTraceWriter.Controllers
{
    public class DemoController : ApiController
    {
        public DemoController()
        {
        }

        public HttpResponseMessage Get()
        {
            this.Configuration.Services.GetTraceWriter().Info(Request, "DemoController", "Info: Get()");
            this.Configuration.Services.GetTraceWriter().Debug(Request, "DemoController", "Debug: Get()");

            return new HttpResponseMessage();
        }

    }
}
