using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevF_LABS.Test.StoredProcedure
{
    [TestClass]
    public class StoredProcedure_Creator_Test
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["MSSQL_EF_CF_Context"].ConnectionString;
        private const string authorname = "bhdryrdm";
        SP_CreateOrAlter_Queries sP_CreateOrAlter_Queries;
        public StoredProcedure_Creator_Test()
        {
            this.sP_CreateOrAlter_Queries = new SP_CreateOrAlter_Queries(connectionString, authorname);
        }

        /// <summary>
        /// XSS Yorum tablosunda 10 yorum aşıldığında 1. sıradaki yorumu siler
        /// </summary>
        [TestMethod]
        public void Create_DeleteInXSSComment_Trigger()
        {
            sP_CreateOrAlter_Queries.DeleteInXSSComment_Trigger();
        }

        /// <summary>
        /// XSS Cookie tablosunda 50 yorum aşıldığında 1.sıradaki cookie siler 
        /// </summary>
        [TestMethod]
        public void Create_DeleteInXSSCookie_Trigger()
        {
            sP_CreateOrAlter_Queries.DeleteInXSSCookie_Trigger();
        }

        /// <summary>
        /// XSS User tablosunda 5 kullanıcı aşıldığında 1.sıradaki kullanıcı siler
        /// </summary>
        [TestMethod]
        public void Create_DeleteInXSSUser_Trigger()
        {
            sP_CreateOrAlter_Queries.DeleteInXSSUser_Trigger();
        }
    }
}
