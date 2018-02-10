using DevF_LABS.Presentation.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevF_LABS.Presentation.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult SessionUserList() => PartialView();
    }
}