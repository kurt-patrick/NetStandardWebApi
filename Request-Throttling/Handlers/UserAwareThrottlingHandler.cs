using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using WebApiContrib.Caching;
using WebApiContrib.MessageHandlers;

namespace Request_Throttling.Handlers
{
    public class UserAwareThrottlingHandler : ThrottlingHandler
    {
        public UserAwareThrottlingHandler(IThrottleStore store, Func<string, long> maxRequestsForUserIdentifier, TimeSpan period, string message) : base(store, maxRequestsForUserIdentifier, period, message)
        {
        }

        protected override string GetUserIdentifier(HttpRequestMessage request)
        {
            var user = request.GetRequestContext().Principal;
            if (user != null)
            {
                if (string.IsNullOrWhiteSpace(user.Identity.Name))
                {
                    return "Guest";
                }
                return user.Identity.Name;
            }
            return base.GetUserIdentifier(request);
        }
    }
}