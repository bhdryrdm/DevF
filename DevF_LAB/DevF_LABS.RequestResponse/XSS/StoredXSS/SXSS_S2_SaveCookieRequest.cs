using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevF_LABS.RequestResponse.XSS.StoredXSS
{
    public class SXSS_S2_SaveCookieRequest
    {
        [Required(ErrorMessage = "Cookie ismi zorunlu alandır!")]
        [StringLength(30, ErrorMessage = "Cookie ismi 30 karakterden fazla olamaz!")]
        public string SXSS_S2_SaveCookeRequest_CookieName { get; set; }

        [Required(ErrorMessage = "Cookie değeri zorunlu alandır!")]
        [StringLength(30, ErrorMessage = "Cookie değeri 30 karakterden fazla olamaz!")]
        public string SXSS_S2_SaveCookeRequest_CookieValue { get; set; }

        [Required(ErrorMessage = "Cookie Httponly bilgisi zorunlu alandır!")]
        public bool SXSS_S2_SaveCookeRequest_CookieHttponly { get; set; }

        [Required(ErrorMessage = "GReCaptcha zorunlu alandır!")]
        public string SXSS_S2_SaveCookeRequest_gReCaptcha { get; set; }
    }
}
