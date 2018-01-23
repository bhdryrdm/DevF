using DevF_LABS.RequestResponse.XSS.ReflectedXSS;
using OWASP.Helper;
using System;
using System.Linq;
using System.Web.Mvc;

namespace OWASP.Controllers
{
    public class XssController : BaseController
    {
        public ActionResult Index()
        {
            Session["LoginUserRole"] = "";
            return View("");
        }

        [HttpPost]
        public ActionResult RXSS_S3_Login(RXSS_S3_LoginRequest request)
        {
            RXSS_S3_UserListResponse response = new RXSS_S3_UserListResponse();
           
            return PartialView("~/Views/Xss/ReflectedXss/_UserList.cshtml", response);
        }
        [HttpPost]
        public JsonResult RXSS_S3_Register(RXSS_S3_RegisterRequest request)
        {
            RXSS_S3_UserListResponse response = new RXSS_S3_UserListResponse();

            if (!GoogleRecaptchaControl(request.RXSS_S3_RegisterRequest_gReCaptcha))
            {
                response.IsSuccess = false;
                response.Message = "gReCaptcha bilgisi doğrulanamadı!";
                response.ResponseCode = 400;
            }
            else
            {
               
            }

            string userListHTML = RazorViewToString.RenderRazorViewToString(this,"~/Views/Xss/ReflectedXss/_UserList.cshtml", response);
            return Json(new object[]{ userListHTML, response });
        }

        [HttpPost]
        public ActionResult RXSS_S3_Delete(int userID)
        {
            RXSS_S3_UserListResponse response = new RXSS_S3_UserListResponse();
            

            return PartialView("~/Views/Xss/ReflectedXss/_UserList.cshtml", response);
        }
    }
}