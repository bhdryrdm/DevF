using System;

namespace DevF_LABS.Data.MSSQL.EntityFramework.CodeFirst.Tables.XSS
{
    public class XSS_User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string UserRole { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime UpdatedTime { get; set; }
    }
}
