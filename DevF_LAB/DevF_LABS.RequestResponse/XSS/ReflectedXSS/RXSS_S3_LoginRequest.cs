using System.ComponentModel.DataAnnotations;

namespace DevF_LABS.RequestResponse.XSS.ReflectedXSS
{
    public class RXSS_S3_LoginRequest
    {
        [Required(ErrorMessage ="Email zorunlu alandır!")]
        [StringLength(100,ErrorMessage ="Email 100 karakterden fazla olamaz!")]
        [EmailAddress(ErrorMessage = "Email adresi geçerli değil!")]
        public string RXSS_S3_LoginRequest_Email { get; set; }

        [Required(ErrorMessage ="Parola zorunlu alandır!")]
        [StringLength(50,ErrorMessage ="Parola 50 karakterden fazla olamaz!")]
        public string RXSS_S3_LoginRequest_Password { get; set; }
    }
}
