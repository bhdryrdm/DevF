using System.ComponentModel.DataAnnotations;
using Lang = DevF_LABS.Language.Vertical.XSS.XssRequestResponse;

namespace DevF_LABS.RequestResponse.XSS.ReflectedXSS
{
    public class RXSS_S3_DeleteRequest
    {
        [Required(ErrorMessageResourceType = typeof(Lang), ErrorMessageResourceName = "RXSS_S3_DeleteRequest_UserID_Required")]
        [Range(1, int.MaxValue, ErrorMessageResourceType = typeof(Lang), ErrorMessageResourceName = "RXSS_S3_DeleteRequest_UserID_Range")]
        public int UserID { get; set; }
    }
}
