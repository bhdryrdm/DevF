using DevF_LABS.RequestResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;
using System.Web.Security;

namespace DevF_LABS.Presentation.Filter
{
    public class BrokenAccessAuthorizeFilter : ActionFilterAttribute, IAuthenticationFilter
    {
        private const string cookieName = "DevF_LABS_BrokenAccessAuth_CustomCookie";
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            List<string> userData = new List<string>() { "","","","" };
            if (filterContext.HttpContext.Request.Cookies.AllKeys.Contains(cookieName))
            {
                // Session value clear
                filterContext.HttpContext.Session[HttpContext.Current.Session.SessionID + "-BrokenAuthUser"] = "";

                HttpCookie encyptedCookie = HttpContext.Current.Request.Cookies["DevF_LABS_BrokenAccessAuth_CustomCookie"];
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(encyptedCookie.Value);
                userData = ticket.UserData.Split(';').ToList();
                if(userData.Count > 0)
                {
                    filterContext.HttpContext.Session[HttpContext.Current.Session.SessionID + "-BrokenAuthUser"] =$"{userData[0]}  {userData[1]}  {userData[2]}";
                }
            }
           
            if (userData[1] != "admin@devf.com" && userData[3] != "123")
            {
                // Ajax Request
                if (filterContext.HttpContext.Request.IsAjaxRequest())
                {
                    filterContext.Result = new JsonResult
                    {
                        Data = new BaseResponse()
                        {
                            IsSuccess = false,
                            Message = "Oturumunuz sonlanmıştır. Lütfen tekrar giriş yapınız.",
                            ResponseCode = 401
                        },
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }
                else
                {
                    filterContext.Result = new RedirectToRouteResult("Default",
                    new RouteValueDictionary
                    {
                        { "controller", "BrokenAuth" },
                        { "action", "RedirectError" },
                        { "returnUrl", filterContext.HttpContext.Request.RawUrl }
                    });
                }

            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            
        }
    }
}