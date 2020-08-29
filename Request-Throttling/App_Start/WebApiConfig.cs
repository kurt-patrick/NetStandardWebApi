using Request_Throttling.Handlers;
using Request_Throttling.Interfaces;
using Request_Throttling.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using Unity.Lifetime;
using WebApiContrib.Caching;
using WebApiContrib.MessageHandlers;

namespace Request_Throttling
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            if (config == null) { 
                throw new ArgumentNullException(nameof(config));
            }

            // Web API configuration and services
            var unityContainer = new UnityContainer();
            unityContainer.RegisterType<IUserStore, UserRepository>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(unityContainer);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var throttlingHandler = new UserAwareThrottlingHandler(
                new InMemoryThrottleStore(),
                identifier =>
                {
                    var userStore = (IUserStore)config.DependencyResolver.GetService(typeof(IUserStore));
                    var user = userStore.FindByUsername(identifier);
                    if (user != null)
                    {
                        return user.RateLimit;
                    }
                    return 1;
                },
                TimeSpan.FromSeconds(10),
                "Ratelimit has been hit for 10 second period"
            );
            config.MessageHandlers.Add(throttlingHandler);


            // Basic example
            /*
            const long RequestLimit = 1;
            var throttlingHandler = new ThrottlingHandler(
                new InMemoryThrottleStore(),
                ip => RequestLimit,
                TimeSpan.FromSeconds(10),
                $"Only {RequestLimit} request(s) allowed per 10 seconds"
            );

            config.MessageHandlers.Add(throttlingHandler);
            */
        }
    }
}
