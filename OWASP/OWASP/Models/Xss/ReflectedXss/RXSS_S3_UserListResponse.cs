using OWASP_DB.MSSQL.EntityFramework.CodeFirst.Tables.XSS;
using System.Collections.Generic;

namespace OWASP.Models.Xss.ReflectedXss
{
    public class RXSS_S3_UserListResponse : BaseResponse
    {
        public List<XSS_User> UserList { get; set; } = new List<XSS_User>();
        public XSS_User LoginUser { get; set; }
    }
}