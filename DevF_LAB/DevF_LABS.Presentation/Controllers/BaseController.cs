using DevF_LABS.Presentation.Filter;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Web.Configuration;
using System.Web.Mvc;

namespace DevF_LABS.Presentation.Controllers
{
    [ValidateModelFilter]
    [LogActionFilter]
    public class BaseController : Controller
    {
        public string ConnectionString { get; set; } = WebConfigurationManager.ConnectionStrings["MSSQL_EF_CF_Context"].ConnectionString;
        public class CaptchaResponse
        {
            [JsonProperty("success")]
            public bool Success { get; set; }
            [JsonProperty("error-codes")]
            public List<string> Errors { get; set; }
        }

        public bool GoogleRecaptchaControl(string recaptcha)
        {
            bool result = true;
            string secretKey = WebConfigurationManager.AppSettings["gReCaptcha_SecretKey"].ToString();

            WebClient client = new WebClient();
            string reply = client.DownloadString($"https://www.google.com/recaptcha/api/siteverify?secret={secretKey}&response={recaptcha}");

            CaptchaResponse captchaResponse = JsonConvert.DeserializeObject<CaptchaResponse>(reply);

            if (!captchaResponse.Success)
                result = false;

            return result;
        }

    }
}