using DevF_LABS.Data.MSSQL.EntityFramework.CodeFirst;
using DevF_LABS.Data.MSSQL.EntityFramework.CodeFirst.Tables;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DevF_LABS.Test
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
