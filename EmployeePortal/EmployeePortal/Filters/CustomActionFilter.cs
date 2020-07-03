using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeePortal.Filters
{
    public class CustomActionFilter:ActionFilterAttribute
    {

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var controllerName = context.RouteData.Values["controller"];
            var actionName = context.RouteData.Values["action"];
            var message = String.Format("{0} controller:{1} action:{2}", "onactionexecuted", controllerName, actionName);
            Debug.WriteLine(message, "Action Filter Log");
            base.OnActionExecuted(context);
        }
        public override void OnResultExecuted(ResultExecutedContext context)
        {
            var controllerName = context.RouteData.Values["controller"];
            var actionName = context.RouteData.Values["actionbundler"];
            var message = String.Format("{0} controller:{1} action:{2}", "onResultactionexecuted", controllerName, actionName);
            Debug.WriteLine(message, "Action Filter Log"+actionName);
            base.OnResultExecuted(context);
        }
    }
}
