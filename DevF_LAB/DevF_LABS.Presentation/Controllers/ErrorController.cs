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

        public ActionResult BadRequestAjax() => Json("");

        public ActionResult NotFound() => View();

        public ActionResult NotFoundAjax() => Json("");

        public ActionResult ServerError() => View();

        public ActionResult ServerErrorAjax() => Json("");

        public ActionResult NotAuthentication() => View(); 
    }
}