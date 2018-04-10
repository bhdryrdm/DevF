using DevF_LABS.Logs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DevF_LABS.Presentation.Filter
{
    public class LogActionFilter : ActionFilterAttribute, IActionFilter
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string sessionID = filterContext.RequestContext.HttpContext.Session.SessionID;
            string controllerName = filterContext.Controller.ToString();
            string actionName = filterContext.ActionDescriptor.ActionName;
            string dateTime = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss");
            NLogLogger.Log(new Exception("Nothing"), "Log_Action_OnActionExecuting", LogPriority.Low);
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            string sessionID = filterContext.RequestContext.HttpContext.Session.SessionID;
            string controllerName = filterContext.Controller.ToString();
            string actionName = filterContext.ActionDescriptor.ActionName;
            string dateTime = DateTime.Now.ToString("dd-MM-yyyy hh:mm:ss");
            Exception ex = new Exception();
            if (filterContext.ExceptionHandled)
                ex = filterContext.Exception;
            ex.Data.Add("LogActionFilter", $"Executed: -> {controllerName}/{actionName} SessionID : {sessionID} IPAddress : {filterContext.HttpContext.Request.UserHostAddress}");
            NLogLogger.Log(ex, "Log_Action_OnActionExecuted", LogPriority.Low);
        }
    }
}