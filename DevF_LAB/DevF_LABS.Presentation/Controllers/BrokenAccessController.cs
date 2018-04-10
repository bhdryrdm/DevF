using DevF_LABS.Presentation.Filter;
using DevF_LABS.RequestResponse;
using DevF_LABS.RequestResponse.BrokenAuth;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DevF_LABS.Presentation.Controllers
{
    public class BrokenAccessController : BaseController
    {
        private const string cookieName = "DevF_LABS_BrokenAccessAuth_CustomCookie";
        public ActionResult Index() => View();

        public ActionResult RedirectError() => RedirectToAction("NotAuthentication", "Error");

        [HttpPost]
        public JsonResult Login(BrokenAccess_S1_LoginRequest request)
        {
            BaseResponse response = new BaseResponse();
            if(request.BrokenAccess_S1_LoginRequest_Email == "admin@devf.com" && request.BrokenAccess_S1_LoginRequest_Password == "123")
            {
                if(request.BrokenAccess_S1_LoginRequest_LoginType)
                {
                    String cookieValue = $"SessionID:{Session.SessionID}-Email:{request.BrokenAccess_S1_LoginRequest_Email}-IP:{Request.UserHostAddress}"; 
                    FormsAuthentication.SetAuthCookie(cookieValue, true);
                    response.Message = "Tebrikler... Gizli sayfayı görebilirsiniz! /BrokenAuth/SecretPageDefault ";
                    return Json(response);
                }
                else
                {
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket
                    (
                        name: request.BrokenAccess_S1_LoginRequest_Email,
                        cookiePath: FormsAuthentication.FormsCookiePath,
                        issueDate: DateTime.Now,
                        expiration: DateTime.Now + FormsAuthentication.Timeout,
                        isPersistent: true,
                        userData: $"SessionID:{Session.SessionID};Email:{request.BrokenAccess_S1_LoginRequest_Email};IP:{Request.UserHostAddress};{request.BrokenAccess_S1_LoginRequest_Password}",
                        version: 1 
                    );
                    HttpCookie httpCookie = new HttpCookie(cookieName, FormsAuthentication.Encrypt(ticket));
                    httpCookie.Expires = DateTime.Now.AddMonths(1);
                    httpCookie.HttpOnly = true;

                    if (Request.Cookies.AllKeys.Contains(cookieName))
                        Response.SetCookie(httpCookie);
                    else
                        Response.AppendCookie(httpCookie);

                    response.Message = "Tebrikler... Gizli sayfayı görebilirsiniz! /BrokenAuth/SecretPageCustom ";
                    return Json(response);
                }
            }
            response.IsSuccess = false;
            response.Message = "Kullanıcı bulunmadı!";
            response.ResponseCode = 404; 
            return Json(response);
        }

        [Authorize]
        public ActionResult SecretPageDefault()
        {
            ViewBag.Username = HttpContext.User.Identity.Name;
            return View("~/Views/BrokenAccess/SecretPage.cshtml");
        }

        [BrokenAccessAuthorizeFilter]
        public ActionResult SecretPageCustom()
        {
            ViewBag.Username = Session[Session.SessionID + "-BrokenAuthUser"];
            return View("~/Views/BrokenAccess/SecretPage.cshtml");
        }

        public ActionResult AuthorityForgottenPage() => View();
    }
}