using DevF_LABS.Helper;
using DevF_LABS.Presentation.Helper;
using System.Linq;
using System.Web.Mvc;

namespace DevF_LABS.Presentation.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index() => View();


        public ActionResult OnlineUserCount()
        {
            SessionUserModel activeSessionUser = SessionCountHelper.SessionUserList.FirstOrDefault(x => x.SessionID == Session.SessionID);
            SessionCountHelper.SessionUserList.Select(x => { x.IsActiveSession = false; return x; }).ToList();
            if (activeSessionUser != null)
                activeSessionUser.IsActiveSession = true;
            SessionCountHelper.SessionUserList = SessionCountHelper.SessionUserList.OrderByDescending(x => x.IsActiveSession).Take(10).ToList();

            ViewData["SessionCount"] = SessionCountHelper.SessionCount;
            ViewData["SessionUserList"] = RazorViewToString.RenderRazorViewToString(this, "~/Views/User/_SessionUserList.cshtml", SessionCountHelper.SessionUserList);
            return PartialView("~/Views/Shared/PartialLayout/_SessionCount.cshtml");
        }
    }
}