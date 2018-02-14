using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevF_LABS.Data.MSSQL.EntityFramework.CodeFirst.Tables.Injection
{
    public class SQLInjection_User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Usersurname { get; set; }
        public string Password { get; set; }
    }
}
