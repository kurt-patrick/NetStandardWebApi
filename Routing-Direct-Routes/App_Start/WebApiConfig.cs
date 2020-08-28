using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Routing_Direct_Routes
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            // To enable direct routes, the extension method MapHttpAttributeRoutes() must be called
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
