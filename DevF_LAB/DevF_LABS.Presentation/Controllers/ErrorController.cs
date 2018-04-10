using DevF_LABS.RequestResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace DevF_LABS.Presentation.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult BadRequest() => View();

        public ActionResult BadRequestAjax() => Json(new BaseResponse { IsSuccess = false, Message = Session["error"].ToString(), ResponseCode = (int)Session["responseCode"] });

        public ActionResult NotFound() => View();

        public ActionResult NotFoundAjax() => Json(new BaseResponse { IsSuccess = false, Message = Session["error"].ToString(), ResponseCode = (int)Session["responseCode"] });

        public ActionResult ServerError() => View();

        public ActionResult ServerErrorAjax() => Json(new BaseResponse { IsSuccess = false, Message = Session["error"].ToString(), ResponseCode = (int)Session["responseCode"] });

        public ActionResult NotAuthentication() => View();

        public ActionResult NotAuthorized() => View();
    }
}