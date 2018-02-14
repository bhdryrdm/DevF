using DevF_LABS.RequestResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DevF_LABS.Presentation.Controllers
{
    public class LanguageController : Controller
    {
        [HttpPost]
        public JsonResult SwitchLanguage(string lang)
        {
            BaseResponse response = new BaseResponse();
            string language = String.Empty;
            switch (lang)
            {
                case "en":
                    language = "English";
                    break;
                case "tr":
                    language = "Turkish";
                    break;
                default:
                    break;
            }
            HttpCookie httpCookie = new HttpCookie("Language", language);
            httpCookie.Expires = DateTime.Now.AddMonths(1);
            httpCookie.Path = FormsAuthentication.FormsCookiePath;
            httpCookie.HttpOnly = true;

            // SSL sertifikası bulunan domainler için kullanılması yararlıdır.Http üzerinden cookie gönderilemez
            // httpCookie.Secure = true;

            if (Request.Cookies.AllKeys.Contains(language))
            {
                Response.SetCookie(httpCookie);
            }
            else
            {
                Response.AppendCookie(httpCookie);
            }

            return Json(response);
        }
    }
}