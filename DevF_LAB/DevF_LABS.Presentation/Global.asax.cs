using DevF_LABS.Business.Mapping_Express;
using DevF_LABS.Presentation.Helper;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Linq;
using System.Net;

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
            
        }

        protected void Application_EndRequest()
        {
            //HttpContext.Current.Response.AddHeader("Test", "Test");
            //HttpContext.Current.Response.AddHeader("X-Frame-Options", "DENY");
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Application.Lock();
            Application["LiveSessionsCount"] = (int)Application["LiveSessionsCount"] + 1;
            SessionUserModel sessionUserModel = new SessionUserModel
            {
                IsMobile = Request.Browser.IsMobileDevice ? "Mobile" : "Web",
                IPAddress = Request.UserHostAddress,
                SessionID = Session.SessionID,
                OperatingSystem = GetUserPlatform(Request.UserAgent),
                CreatedTime = DateTime.Now
            };

            SessionCountHelper.SessionUserList.Add(sessionUserModel);
            SessionCountHelper.SessionCount = (int)Application["LiveSessionsCount"];
            Application.UnLock();
        }

        protected void Session_End(object sender, EventArgs e)
        {
            Application.Lock();
            Application["LiveSessionsCount"] = (int)Application["LiveSessionsCount"] - 1;
            SessionUserModel deletedModel = SessionCountHelper.SessionUserList.FirstOrDefault(x => x.SessionID == Session.SessionID);
            SessionCountHelper.SessionUserList.Remove(deletedModel);
            SessionCountHelper.SessionCount = (int)Application["LiveSessionsCount"];
            Application.UnLock();
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Application.Lock();
            Exception exception = Server.GetLastError();
            Response.Clear();

            HttpException httpException = exception as HttpException;
            if (httpException != null)
            {
                string returnAjaxResponse = new HttpRequestWrapper(Request).IsAjaxRequest() ? "Ajax" : "";
                RouteData routeData = new RouteData();
                routeData.Values.Add("controller", "Error");
                switch (httpException.GetHttpCode())
                {
                    case 400:
                        routeData.Values.Add("action", "BadRequest" + returnAjaxResponse);
                        Response.StatusCode = 400;
                        break;
                    case 404:
                        routeData.Values.Add("action", "NotFound" + returnAjaxResponse);
                        Response.StatusCode = 404;
                        break;
                    case 500:
                        routeData.Values.Add("action", "ServerError" + returnAjaxResponse);
                        Response.StatusCode = 500;
                        break;
                    default:
                        routeData.Values.Add("action", "NotFoundJSON"); break;
                }

                if(HttpContext.Current.Session != null)
                {
                    Session["error"] = exception.Message;
                    Session["responseCode"] = Response.StatusCode;
                }

                Server.ClearError();
                Response.RedirectToRoute(routeData.Values);
            }
            Application.UnLock();
        }

        public String GetUserPlatform(string userAgent)
        {

            if (userAgent.Contains("Linux"))
                return "Linux";

            if (userAgent.Contains("RIM Tablet") || (userAgent.Contains("BB") && userAgent.Contains("Mobile")))
                return "Black Berry";

            if (userAgent.Contains("Mac OS"))
                return "Mac OS";

            if (userAgent.Contains("Windows NT 5.1") || userAgent.Contains("Windows NT 5.2"))
                return "Windows XP";

            if (userAgent.Contains("Windows NT 6.0"))
                return "Windows Vista";

            if (userAgent.Contains("Windows NT 6.1"))
                return "Windows 7";

            if (userAgent.Contains("Windows NT 6.2"))
                return "Windows 8";

            if (userAgent.Contains("Windows NT 6.3"))
                return "Windows 8.1";

            if (userAgent.Contains("Windows NT 10"))
                return "Windows 10";

            return "Not Detected";
        }
    }
}
