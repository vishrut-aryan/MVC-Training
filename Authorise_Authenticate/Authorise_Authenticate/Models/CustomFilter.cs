using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Authorise_Authenticate.Models
{
    public class LogDetails : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext) { }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Log("OnActionExecuting", filterContext.RouteData);            
        }

        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            base.OnResultExecuting(filterContext);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            base.OnResultExecuted(filterContext);
        }

        private void Log(string methodName, RouteData routeData)
        {
            var controllerName = routeData.Values["controller"];
            var actionName = routeData.Values["action"];
            var message = String.Format("{0} controller : {1} action : {2}, executed at {3}", methodName, controllerName, actionName, System.DateTime.Now.ToString());

            string fpath = System.Configuration.ConfigurationManager.AppSettings["Log_Path"].ToString();
            File.AppendAllText(fpath, message);
        }
    }
}