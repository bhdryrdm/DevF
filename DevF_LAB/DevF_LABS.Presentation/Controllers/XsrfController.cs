using DevF_LABS.Presentation.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OWASP.Controllers
{
    public class XsrfController : BaseController
    {
        public ActionResult Index() => View();
    }
}