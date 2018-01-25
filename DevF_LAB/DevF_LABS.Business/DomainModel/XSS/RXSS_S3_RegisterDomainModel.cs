using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevF_LABS.Business.DomainModel.XSS
{
    public class RXSS_S3_RegisterDomainModel
    {
        public string RXSS_S3_RegisterRequest_UserName { get; set; }
        public string RXSS_S3_RegisterRequest_UserSurname { get; set; }
        public string RXSS_S3_RegisterRequest_Email { get; set; }
        public string RXSS_S3_RegisterRequest_Password_Hash { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
    }
}
