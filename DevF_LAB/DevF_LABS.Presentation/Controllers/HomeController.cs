using DevF_LABS.Helper;
using DevF_LABS.Presentation.Helper;
using DevF_LABS.Presentation.Redis;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace DevF_LABS.Presentation.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index() => View();


        public ActionResult OnlineUserCount()
        {
            RedisCacheManager redisCacheManager = RedisCacheManager.CreateRedisDatabase();
            List<SessionUserModel> redisSessionUserList = redisCacheManager.Get<List<SessionUserModel>>("SessionUsers");

            if (redisSessionUserList != null)
            {
                SessionUserModel activeSessionUser = redisSessionUserList.FirstOrDefault(x => x.SessionID == Session.SessionID);
                redisSessionUserList.Select(x => { x.IsActiveSession = false; return x; }).ToList();
                if (activeSessionUser != null)
                    activeSessionUser.IsActiveSession = true;
                redisSessionUserList = redisSessionUserList.OrderByDescending(x => x.IsActiveSession).Take(10).ToList();
            }

            ViewData["SessionCount"] = redisCacheManager.GetInt("LiveSessionCount");
            ViewData["SessionUserList"] = RazorViewToString.RenderRazorViewToString(this, "~/Views/User/_SessionUserList.cshtml", redisSessionUserList);
            return PartialView("~/Views/Shared/PartialLayout/_SessionCount.cshtml");
        }
    }
}