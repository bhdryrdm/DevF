using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DevF_LABS.Data.MSSQL.EntityFramework.CodeFirst.Tables.XSS;
using DevF_LABS.Data.MSSQL.EntityFramework.CodeFirst;

namespace DevF_LABS.Test.DummyData
{
    /// <summary>
    /// Summary description for XSS_DummyData_Tests
    /// </summary>
    [TestClass]
    public class XSS_DummyData_Tests
    {

        [TestMethod]
        public void Create_XSSUser_DummyData()
        {
            try
            {
                List<XSS_User> listXSS_User = new List<XSS_User>
                {
                    new XSS_User{ UserName ="AdminUser", UserSurname = "DevF", Email = "admin@devf.com", Password = "123" ,
                                  UserRole = "Admin" , CreatedTime= DateTime.Now, UpdatedTime = DateTime.Now},
                    new XSS_User{ UserName ="DemoUser", UserSurname = "DevF", Email = "demo@devf.com", Password = "456" ,
                                  UserRole = "Demo" , CreatedTime= DateTime.Now, UpdatedTime = DateTime.Now},
                };

                using (MSSQL_EF_CF_Context dbContext = new MSSQL_EF_CF_Context())
                {
                    foreach (var xssUser in listXSS_User)
                    {
                        dbContext.XSS_User.Add(xssUser);
                    }
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
