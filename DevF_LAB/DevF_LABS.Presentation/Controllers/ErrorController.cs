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
        public ActionResult BadRequest()
        {
            return View();
        }

        public ActionResult BadRequestAjax()
        {
            return PartialView();
        }
        public ActionResult NotFound()
        {
            return View();
        }

        public ActionResult NotFoundAjax()
        {
            return View();
        }

        public ActionResult ServerError()
        {
            return View();
        }
        public ActionResult ServerErrorAjax()
        {
            return new HttpStatusCodeResult((int)Session["responseCode"], Session["error"].ToString()); 
        }
    }
}