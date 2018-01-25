using DevF_LABS.Business.Mapping_Express;
using System.Web.Mvc;
using System.Web.Routing;

namespace DevF_LABS.Presentation
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Mapper_Bootstrapper.RegisterMapping();

            Application["LiveSessionsCount"] = 0;
        }

        protected void Application_BeginRequest()
        {
            Response.AddHeader("X-Frame-Options", "DENY");
        }

        protected void Application_EndRequest()
        {
            Response.AddHeader("Test", "Test");
        }

        protected void Session_Start()
        {
            Application.Lock();
            Application["LiveSessionsCount"] = ((int)Application["LiveSessionsCount"]) + 1;
            Session["OnlineSessionCount"] = Application["LiveSessionsCount"];
            Application.UnLock();
        }
        protected void Session_End()
        {
            Application.Lock();
            Application["LiveSessionsCount"] = ((int)Application["LiveSessionsCount"]) - 1;
            Session["OnlineSessionCount"] = Application["LiveSessionsCount"];
            Application.UnLock();
        }
    }
}
