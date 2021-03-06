﻿using DevF_LABS.RequestResponse;
using System.Net;
using System.Text;
using System.Web.Mvc;

namespace DevF_LABS.Presentation.Filter
{
    public class ValidateModelFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.Controller.ViewData.ModelState.IsValid == false)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("Gönderdiğiniz değerlerden bazıları hatalı gönderilmiş  ya da  istenen formata uygun değildir!");
                sb.Append("Lütfen aşağıda belirtilmiş olan değerleri kontrol ediniz.");
                foreach (var value in filterContext.Controller.ViewData.ModelState.Values)
                {
                    if (value.Errors.Count > 0)
                    {
                        foreach (var item in value.Errors)
                        {
                            sb.Append($"<br /><b>{item.ErrorMessage}</b>");
                        }
                    }
                }
                filterContext.Result = new JsonResult { Data = new BaseResponse { IsSuccess = false, Message = sb.ToString(), ResponseCode = 400 } };
            }
            else
            {
                base.OnActionExecuting(filterContext);
            }
        }
    }
}