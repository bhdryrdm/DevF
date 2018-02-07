using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevF_LABS.RequestResponse.XSS.StoredXSS
{
    public class SXSS_S2_StealRequest
    {
        [Required(ErrorMessage = "Kullanıcı İsim-Soyisim zorunlu alandır!")]
        [StringLength(500, ErrorMessage = "Kullanıcı İsim-Soyisim 500 karakterden fazla olamaz!")]
        public string SXSS_S2_StealRequest_Cookie { get; set; }
        public string SessionID { get; set; }
    }
}
