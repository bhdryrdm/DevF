using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevF_LABS.RequestResponse.XSS.StoredXSS
{
    public class SXSS_S3_CKEditor_Request
    {
        [Required(ErrorMessage = "CKEditor değeri zorunlu alandır!")]
        [StringLength(4000, ErrorMessage = "Cookie ismi 4000 karakterden fazla olamaz!")]
        public string SXSS_S3_CKEditorRequest_Value { get; set; }

        [Required(ErrorMessage = "GReCaptcha zorunlu alandır!")]
        public string SXSS_S3_CKEditorRequest_gReCaptcha { get; set; }

    }
}
