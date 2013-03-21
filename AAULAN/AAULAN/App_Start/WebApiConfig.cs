using System.Web.Http;
using System.Web.UI;

namespace AAULAN.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional }
            );

            var str = "1.7.1";
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
            {
                Path = "~/Scripts/jquery-" + str + ".min.js",
                DebugPath = "~/Scripts/jquery-" + str + ".js",
                CdnPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-" + str + ".min.js",
                CdnDebugPath = "http://ajax.aspnetcdn.com/ajax/jQuery/jquery-" + str + ".js",
                CdnSupportsSecureConnection = true,
                LoadSuccessExpression = "window.jQuery"
            });

            str = "1.8.20";
            ScriptManager.ScriptResourceMapping.AddDefinition("jquery.ui.combined", new ScriptResourceDefinition
            {
                Path = "~/Scripts/jquery-ui-" + str + ".min.js",
                DebugPath = "~/Scripts/jquery-ui-" + str + ".js",
                CdnPath = "http://ajax.aspnetcdn.com/ajax/jquery.ui/" + str + "/jquery-ui.min.js",
                CdnDebugPath = "http://ajax.aspnetcdn.com/ajax/jquery.ui/" + str + "/jquery-ui.js",
                CdnSupportsSecureConnection = true
            });
        }
    }
}
