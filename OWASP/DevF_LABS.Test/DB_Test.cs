using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OWASP_DB.MSSQL.EntityFramework.CodeFirst.Tables;
using OWASP_DB.MSSQL.EntityFramework.CodeFirst;

namespace OWASP_TEST
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateDB()
        {
            Settings settigns = new Settings { ID = 1 };
            using (var dbContext = new MSSQL_EF_CF_Context())
            {
                dbContext.Settings.Add(settigns);
                dbContext.SaveChanges();
            }
        }
    }
}
