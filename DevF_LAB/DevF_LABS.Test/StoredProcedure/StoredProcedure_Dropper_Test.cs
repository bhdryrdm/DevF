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
    public class StoredProcedure_Dropper_Test
    {
        protected static string connectionString = ConfigurationManager.ConnectionStrings["MSSQL_EF_CF_Context"].ConnectionString;
        SP_Drop_Queries sp_Drop_Queries;
        public StoredProcedure_Dropper_Test(string connectionString)
        {
            this.sp_Drop_Queries = new SP_Drop_Queries(connectionString);
        }
        

        [TestMethod]
        public void Drop_Create_DeleteInXSSComment_Trigger()
        {
            sp_Drop_Queries.DropTrigger("DeleteInXSSComment", null);
        }

        [TestMethod]
        public void Drop_DeleteInXSSCookie_Trigger()
        {
            sp_Drop_Queries.DropTrigger("DeleteInXSSCookie", null);
        }

        [TestMethod]
        public void Drop_DeleteInXSSUser_Trigger()
        {
            sp_Drop_Queries.DropTrigger("DeleteInXSSUser", null);
        }

        [TestMethod]
        public void Drop_DeleteInSQLInjectionUser_Trigger()
        {
            sp_Drop_Queries.DropTrigger("DeleteInSQLInjectionUser", null);
        }


    }

}
