using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevF_LABS.Data.MSSQL.EntityFramework.CodeFirst.Tables.XSS
{
    public class XSS_Cookie
    {
        public int ID { get; set; }
        public string CookieName { get; set; }
        public string CookieValue { get; set; }
        public string SessionID { get; set; }
    }
}
