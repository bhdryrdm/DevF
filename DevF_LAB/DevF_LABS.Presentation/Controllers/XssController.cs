using DevF_LABS.Business.BusinessServices;
using DevF_LABS.RequestResponse.XSS.ReflectedXSS;
using DevF_LABS.RequestResponse.XSS.StoredXSS;
using OWASP.Helper;
using System;
using System.Web.Mvc;

namespace DevF_LABS.Presentation.Controllers
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
            RXSS_S3_UserListResponse response = XSS_BusinessServices.RXSS_S3_Login(request);
            Session["LoginUserRole"] = response.LoginUser != null ? response.LoginUser.UserRole: "User" ;
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
                response = XSS_BusinessServices.RXSS_S3_Register(request);
                Session["LoginUserRole"] = response.LoginUser.UserRole;
            }

            string userListHTML = RazorViewToString.RenderRazorViewToString(this,"~/Views/Xss/ReflectedXss/_UserList.cshtml", response);
            return Json(new object[]{ userListHTML, response });
        }

        [HttpPost]
        public ActionResult RXSS_S3_Delete(RXSS_S3_DeleteRequest request)
        {
            RXSS_S3_UserListResponse response = new RXSS_S3_UserListResponse();

            if (Session["LoginUserRole"].ToString() == "Admin")
            {
                 response = XSS_BusinessServices.RXSS_S3_Delete(request);
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "İşlem yetkiniz bulunmamaktadır!";
                response.ResponseCode = 403;
            }
            string userListHTML = RazorViewToString.RenderRazorViewToString(this, "~/Views/Xss/ReflectedXss/_UserList.cshtml", response);
            return Json(new object[] { userListHTML, response });
        }

        [HttpPost]
        public ActionResult SXSS_S1_Comment(SXSS_S1_CommentRequest request)
        {
            
            SXSS_S1_CommentListResponse response = new SXSS_S1_CommentListResponse();
            if (!GoogleRecaptchaControl(request.SXSS_S1_CommentRequest_gReCaptcha))
            {
                response.IsSuccess = false;
                response.Message = "gReCaptcha bilgisi doğrulanamadı!";
                response.ResponseCode = 400;
            }
            else
            {
                response = XSS_BusinessServices.SXSS_S1_Comment(request);
            }
            return PartialView("~/Views/Xss/StoredXss/_CommentList.cshtml", response);
        }
    }
}