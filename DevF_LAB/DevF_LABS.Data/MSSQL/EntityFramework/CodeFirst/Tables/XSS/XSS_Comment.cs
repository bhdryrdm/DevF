using System;

namespace DevF_LABS.Data.MSSQL.EntityFramework.CodeFirst.Tables.XSS
{
    public class XSS_Comment
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
        public DateTime CreatedTime { get; set; }
    }
}
