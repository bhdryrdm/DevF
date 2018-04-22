using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevF_LABS.Presentation.Controllers
{
    public class KnownVulnerabilitiesController : Controller
    {
        // GET: KnownVulnerabilities
        public ActionResult Index()
        {
            return View();
        }
    }
}