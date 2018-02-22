using System.ComponentModel.DataAnnotations;

namespace DevF_LABS.RequestResponse.Injection.SQLInjection
{
    public class SQLI_S1_LoginRequest
    {
        [Required(ErrorMessage = "Kullanıcı Adı zorunlu alandır!")]
        [StringLength(200, ErrorMessage = "Kullanıcı Adı 200 karakterden fazla olamaz!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Parola zorunlu alandır!")]
        [StringLength(20, ErrorMessage = "Parola 20 karakterden fazla olamaz!")]
        [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "Lütfen harf ve sayı haricinde karakter girmeyiniz.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "ORM kontrolü zorunlu alandır!")]
        public bool ORM_Control { get; set; }
    }
}
