using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevF_LABS.RequestResponse.BrokenAuth
{
    public class BrokenAccess_S1_LoginRequest
    {
        [Required(ErrorMessage = "Email zorunlu alandır!")]
        [StringLength(100, ErrorMessage = "Email 100 karakterden fazla olamaz!")]
        [EmailAddress(ErrorMessage = "Email adresi geçerli değil!")]
        public string BrokenAccess_S1_LoginRequest_Email { get; set; }

        [Required(ErrorMessage = "Parola zorunlu alandır!")]
        [StringLength(50, ErrorMessage = "Parola 50 karakterden fazla olamaz!")]
        public string BrokenAccess_S1_LoginRequest_Password { get; set; }

        [Required(ErrorMessage = "Giriş türü zorunlu alandır!")]
        public bool BrokenAccess_S1_LoginRequest_LoginType { get; set; }

        public string __RequestVerificationToken { get; set; }
    }
}
