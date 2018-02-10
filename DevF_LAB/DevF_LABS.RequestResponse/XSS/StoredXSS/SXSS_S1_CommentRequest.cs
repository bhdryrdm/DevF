using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevF_LABS.RequestResponse.XSS.StoredXSS
{
    public class SXSS_S1_CommentRequest
    {
        [Required(ErrorMessage = "Kullanıcı İsim-Soyisim zorunlu alandır!")]
        [StringLength(100, ErrorMessage = "Kullanıcı İsim-Soyisim 100 karakterden fazla olamaz!")]
        public string SXSS_S1_CommentRequest_Name { get; set; }

        [Required(ErrorMessage = "Mesaj zorunlu alandır!")]
        [StringLength(1500, ErrorMessage = "Mesajınız 1500 karakterden fazla olamaz!")]
        public string SXSS_S1_CommentRequest_Comment { get; set; }

        [Required(ErrorMessage = "Email zorunlu alandır!")]
        [StringLength(100, ErrorMessage = "Email 100 karakterden fazla olamaz!")]
        [EmailAddress(ErrorMessage = "Email adresi geçerli değil!")]
        public string SXSS_S1_CommentRequest_Email { get; set; }

        [Required(ErrorMessage = "GReCaptcha zorunlu alandır!")]
        public string SXSS_S1_CommentRequest_gReCaptcha { get; set; }
    }
}
