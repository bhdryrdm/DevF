using DevF_LABS.Data.MSSQL.EntityFramework.CodeFirst;
using DevF_LABS.Data.MSSQL.EntityFramework.CodeFirst.Tables;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DevF_LABS.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateDB()
        {
            try
            {
                //PK olarak işaretlenmiş 1 artır
                Settings settigns = new Settings { ID = 2 };
                using (var dbContext = new MSSQL_EF_CF_Context())
                {
                    dbContext.Settings.Add(settigns);
                    dbContext.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
