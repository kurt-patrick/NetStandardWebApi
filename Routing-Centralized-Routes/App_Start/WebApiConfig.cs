﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Routing_Centralized_Routes
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "players",
                routeTemplate: "api/teams/{teamid}/players",
                defaults: new { controller = "teams" }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
