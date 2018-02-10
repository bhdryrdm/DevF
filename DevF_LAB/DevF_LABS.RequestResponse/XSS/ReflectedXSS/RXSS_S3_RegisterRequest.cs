using System.ComponentModel.DataAnnotations;

namespace DevF_LABS.RequestResponse.XSS.ReflectedXSS
{
    public class RXSS_S3_RegisterRequest
    {
        [Required(ErrorMessage = "Kullanıcı adı zorunlu alandır!")]
        [StringLength(100, ErrorMessage = "Kullanıcı adı 100 karakterden fazla olamaz!")]
        public string RXSS_S3_RegisterRequest_UserName { get; set; }

        [Required(ErrorMessage = "Kullanıcı soyadı zorunlu alandır!")]
        [StringLength(100, ErrorMessage = "Kullanıcı soyadı 100 karakterden fazla olamaz!")]
        public string RXSS_S3_RegisterRequest_UserSurname { get; set; }

        [Required(ErrorMessage = "Email zorunlu alandır!")]
        [StringLength(100, ErrorMessage = "Email 100 karakterden fazla olamaz!")]
        [EmailAddress(ErrorMessage = "Email adresi geçerli değil!")]
        public string RXSS_S3_RegisterRequest_Email { get; set; }

        [Required(ErrorMessage = "Parola zorunlu alandır!")]
        [StringLength(50, ErrorMessage = "Parola 50 karakterden fazla olamaz!")]
        public string RXSS_S3_RegisterRequest_Password { get; set; }

        [Required(ErrorMessage = "GReCaptcha zorunlu alandır!")]
        public string RXSS_S3_RegisterRequest_gReCaptcha { get; set; }
    }
}
