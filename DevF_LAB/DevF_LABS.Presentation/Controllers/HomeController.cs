using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevF_LABS.Presentation.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index() => View();

        
        public ActionResult OnlineUserCount()
        {
            ViewData["OnlineSessionCount"] = (int)Session["OnlineSessionCount"];
            return PartialView("~/Views/Shared/PartialLayout/_SessionCount.cshtml");
        }
    }
}