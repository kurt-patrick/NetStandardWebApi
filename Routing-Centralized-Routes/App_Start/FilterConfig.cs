using System.Web;
using System.Web.Mvc;

namespace Routing_Centralized_Routes
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
