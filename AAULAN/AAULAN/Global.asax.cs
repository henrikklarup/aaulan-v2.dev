using System;
using System.Security.Principal;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using AAULAN.App_Start;

namespace AAULAN
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
        
        protected void Application_AuthenticateRequest(Object sender, EventArgs e)
        {
            //Fires upon attempting to authenticate the user
            if (HttpContext.Current.User == null) return;
            if (!HttpContext.Current.User.Identity.IsAuthenticated) return;
            if (HttpContext.Current.User.Identity.GetType() != typeof (FormsIdentity)) return;
            var fi = (FormsIdentity) HttpContext.Current.User.Identity;
            var fat = fi.Ticket;

            var astrRoles = fat.UserData.Trim().Split('|');
            HttpContext.Current.User = new GenericPrincipal(fi, astrRoles);
        }
    }
}