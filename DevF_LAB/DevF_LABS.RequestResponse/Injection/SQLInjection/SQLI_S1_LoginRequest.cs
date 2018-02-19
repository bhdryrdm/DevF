using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevF_LABS.RequestResponse.Injection.SQLInjection
{
    public class SQLI_S1_LoginRequest
    {
        [Required(ErrorMessage = "Kullanıcı Adı zorunlu alandır!")]
        [StringLength(20, ErrorMessage = "Kullanıcı Adı 20 karakterden fazla olamaz!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Parola zorunlu alandır!")]
        [StringLength(50, ErrorMessage = "Parola 50 karakterden fazla olamaz!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "ORM kontrolü zorunlu alandır!")]
        public bool ORM_Control { get; set; }
    }
}
