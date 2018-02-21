using DevF_LABS.Business.BusinessServices;
using DevF_LABS.Helper;
using DevF_LABS.RequestResponse;
using DevF_LABS.RequestResponse.XSS.ReflectedXSS;
using DevF_LABS.RequestResponse.XSS.StoredXSS;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Security.AntiXss;
using Lang = DevF_LABS.Language.Presentation.Controllers.XssController;

namespace DevF_LABS.Presentation.Controllers
{
    public class XssController : BaseController
    {
        public ActionResult Index()
        {
            Session["LoginUserRole"] = "";
            return View("");
        }

        #region Reflected XSS
        [HttpPost]
        public JsonResult RXSS_S3_Login(RXSS_S3_LoginRequest request)
        {
            RXSS_S3_UserListResponse response = XSS_BusinessServices.RXSS_S3_Login(request);
            Session["LoginUserRole" + Session.SessionID] = response.LoginUser != null ? response.LoginUser.UserRole : "User";
            string userListHTML = RazorViewToString.RenderRazorViewToString(this, "~/Views/Xss/ReflectedXss/_UserList.cshtml", response);
            return Json(new object[] { userListHTML, response });
        }

        [HttpPost]
        public JsonResult RXSS_S3_Register(RXSS_S3_RegisterRequest request)
        {
            RXSS_S3_UserListResponse response = new RXSS_S3_UserListResponse();

            if (!GoogleRecaptchaControl(request.RXSS_S3_RegisterRequest_gReCaptcha))
            {
                response.IsSuccess = false;
                response.Message = Lang.Global_GReCaptcha;
                response.ResponseCode = 400;
            }
            else
            {
                response = XSS_BusinessServices.RXSS_S3_Register(request);
                Session["LoginUserRole" + Session.SessionID] = response.LoginUser.UserRole;
            }

            string userListHTML = RazorViewToString.RenderRazorViewToString(this, "~/Views/Xss/ReflectedXss/_UserList.cshtml", response);
            return Json(new object[] { userListHTML, response });
        }

        [HttpPost]
        public JsonResult RXSS_S3_Delete(RXSS_S3_DeleteRequest request)
        {
            RXSS_S3_UserListResponse response = new RXSS_S3_UserListResponse();

            if (Session["LoginUserRole" + Session.SessionID].ToString() == "Admin")
            {
                response = XSS_BusinessServices.RXSS_S3_Delete(request);
            }
            else
            {
                response.IsSuccess = false;
                response.Message = Lang.Global_Unauthorize;
                response.ResponseCode = 403;
            }
            string userListHTML = RazorViewToString.RenderRazorViewToString(this, "~/Views/Xss/ReflectedXss/_UserList.cshtml", response);
            return Json(new object[] { userListHTML, response });
        }
        #endregion

        #region Stored XSS
        [HttpPost]
        public JsonResult SXSS_S1_Comment(SXSS_S1_CommentRequest request)
        {
            SXSS_S1_CommentListResponse response = new SXSS_S1_CommentListResponse();
            if (!GoogleRecaptchaControl(request.SXSS_S1_CommentRequest_gReCaptcha))
            {
                response.IsSuccess = false;
                response.Message = "Not valid gReCaptcha!";
                response.ResponseCode = 400;
            }
            else
            {
                response = XSS_BusinessServices.SXSS_S1_Comment(request);
            }
            string commentListHTML = RazorViewToString.RenderRazorViewToString(this, "~/Views/Xss/StoredXss/_CommentList.cshtml", response);
            return Json(new object[] { commentListHTML, response });
        }

        [HttpPost]
        public JsonResult SXSS_S1_CommentList()
        {
            SXSS_S1_CommentListResponse response = XSS_BusinessServices.SXSS_S1_CommentList(Session.SessionID);
            string commentListHTML = RazorViewToString.RenderRazorViewToString(this, "~/Views/Xss/StoredXss/_CommentList.cshtml", response);
            return Json(new object[] { commentListHTML, response });
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult SXSS_S1_CommentValidateFalse(SXSS_S1_CommentRequest request)
        {
            SXSS_S1_CommentListResponse response = new SXSS_S1_CommentListResponse();
            if (!GoogleRecaptchaControl(request.SXSS_S1_CommentRequest_gReCaptcha))
            {
                response.IsSuccess = false;
                response.Message = "Not valid gReCaptcha!";
                response.ResponseCode = 400;
            }
            else
            {
                response = XSS_BusinessServices.SXSS_S1_Comment(request);
            }
            string commentListHTML = RazorViewToString.RenderRazorViewToString(this, "~/Views/Xss/StoredXss/_CommentList.cshtml", response);
            return Json(new object[] { commentListHTML, response });
        }

        [HttpPost]
        public JsonResult SXSS_S2_AddCookie(SXSS_S2_SaveCookieRequest request)
        {
            BaseResponse response = new BaseResponse();
            if (!GoogleRecaptchaControl(request.SXSS_S2_SaveCookeRequest_gReCaptcha))
            {
                response.IsSuccess = false;
                response.Message = "Not valid gReCaptcha!";
                response.ResponseCode = 400;
            }
            else
            {
                HttpCookie httpCookie = new HttpCookie(request.SXSS_S2_SaveCookeRequest_CookieName, request.SXSS_S2_SaveCookeRequest_CookieValue);
                httpCookie.Expires = DateTime.Now.AddMonths(1);
                httpCookie.Path = FormsAuthentication.FormsCookiePath;
                if (request.SXSS_S2_SaveCookeRequest_CookieHttponly)
                {
                    httpCookie.HttpOnly = true;
                }

                // SSL sertifikası bulunan domainler için kullanılması yararlıdır.Http üzerinden cookie gönderilemez
                // httpCookie.Secure = true;

                if (Request.Cookies.AllKeys.Contains(request.SXSS_S2_SaveCookeRequest_CookieName))
                {
                    Response.SetCookie(httpCookie);
                }
                else
                {
                    Response.AppendCookie(httpCookie);
                }
            }
            return Json(response);
        }

        [HttpPost]
        public JsonResult SXSS_S2_SaveStolenCookie(SXSS_S2_StealRequest request)
        {
            request.SessionID = Session.SessionID;
            BaseResponse response = XSS_BusinessServices.SXSS_S2_SaveStolenCookie(request);
            return Json(response);
        }

        public ActionResult SXSS_S2_StolenCookieList()
        {
            SXSS_S2_CookieListResponse response = XSS_BusinessServices.SXSS_S2_CookieList(Session.SessionID);
            return View("~/Views/Xss/StoredXss/CookieList.cshtml", response);
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult SXSS_S3_SetCKEditorContent(SXSS_S3_CKEditor_Request request)
        {
            BaseResponse response = XSS_BusinessServices.SXSS_S3_SetCKEditorContent(request);
            return Json(response);
        }

        [HttpPost]
        public JsonResult SXSS_S3_GetCKEditorContent(bool antiXSSControl)
        {
            SXSS_S3_CKEditor_Response response = XSS_BusinessServices.SXSS_S3_GetCKEditorContent();
            if(antiXSSControl)
                response.SXSS_S3_Editor.Content = AntiXssEncoder.HtmlEncode(response.SXSS_S3_Editor.Content, false);
            return Json(response);
        }
        #endregion
    }
}