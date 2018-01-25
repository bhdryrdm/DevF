using System.ComponentModel.DataAnnotations;

namespace DevF_LABS.RequestResponse.XSS.ReflectedXSS
{
    public class RXSS_S3_DeleteRequest
    {
        [Required(ErrorMessage ="Kullanıcı ID zorunlu alandır!")]
        [Range(1, int.MaxValue, ErrorMessage = "Lütfen 1-2147283647 arasında bir değer giriniz!")]
        public int UserID { get; set; }
    }
}
