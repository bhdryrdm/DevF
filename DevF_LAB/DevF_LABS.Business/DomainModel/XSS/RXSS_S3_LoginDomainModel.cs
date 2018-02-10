using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevF_LABS.Business.DomainModel.XSS
{
    public class RXSS_S3_LoginDomainModel
    {

        public string RXSS_S3_LoginRequest_Email { get; set; }

        public string RXSS_S3_LoginRequest_PasswordHash { get; set; }
    }
}
