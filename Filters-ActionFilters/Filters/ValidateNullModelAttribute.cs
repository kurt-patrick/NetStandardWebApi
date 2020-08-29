using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Filters_ActionFilters.Filters
{
    [AttributeUsage(AttributeTargets.Method, Inherited = true)]
    public class ValidateNullModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.ActionArguments.ContainsValue(null))
            {
                string errorMessage =
                    string.Format("The argument cannot be null: {0}", 
                        string.Join(",", actionContext.ActionArguments.Where(i => i.Value == null).Select(i => i.Key)));

                // if you want to see the name of the model passed into your action 
                // Example: public void Post(Item item) with "item" being the name
                // use the code located above
                // if you want a generic message stick with the code below
                errorMessage = $"{actionContext.Request.Method.ToString()} body is required";

                actionContext.Response = actionContext.Request.CreateErrorResponse(
                    System.Net.HttpStatusCode.BadRequest, errorMessage);
            }
        }
    }
}