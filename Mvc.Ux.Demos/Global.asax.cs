///////////////////////////////////////////////////////////////////
//
// Pluralsight : UI Best Practices Playbook for ASP.NET MVC
//
// Author: Dino Esposito
// Youbiquitous.net
//

using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Mvc.Ux.Demos.Controllers;

namespace Mvc.Ux.Demos
{
    public class MvcUxApplication : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var exception = Server.GetLastError();

            var httpContext = ((HttpApplication)sender).Context;
            httpContext.Response.Clear();
            httpContext.ClearError();
            InvokeErrorAction(httpContext, exception);
        }

        #region PRIVATE (Error handling)
        private static void InvokeErrorAction(HttpContext httpContext, Exception exception)
        {
            var routeData = new RouteData();
            routeData.Values["controller"] = "app";
            routeData.Values["action"] = "error";
            routeData.Values["exception"] = exception;

            using (var controller = new AppController())
            {
                ((IController)controller).Execute(new RequestContext(new HttpContextWrapper(httpContext), routeData));
            }
        }
        #endregion

    }
}