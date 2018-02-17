using DevF_LABS.Data.MSSQL.EntityFramework.CodeFirst;
using DevF_LABS.Repository.Mongo_DB_Repository.IRepositories;
using DevF_LABS.Repository.MSSQL_EF_Repository.IRepositories;
using DevF_LABS.Repository.MSSQL_EF_Repository.Repositories;
using System;
using System.Transactions;

namespace DevF_LABS.Repository.MSSQL_EF_Repository
{
    public class MSSQL_UnitOfWork : IUnitOfWork
    {
        private readonly MSSQL_EF_CF_Context context = new MSSQL_EF_CF_Context();

        private SQLInjection_User_Repository sqlInjection_User_Repository;
        public ISQLInjection_User_Repository SQLInjection_User_Repository
        {
            get
            {
                if (sqlInjection_User_Repository == null)
                    sqlInjection_User_Repository = new SQLInjection_User_Repository(context);
                return sqlInjection_User_Repository;
            }
        }

        private XSS_Comment_Repository xss_Comment_Repository;
        public IXSS_Comment_Repository XSS_Comment_Repository
        {
            get
            {
                if (xss_Comment_Repository == null)
                    xss_Comment_Repository = new XSS_Comment_Repository(context);
                return xss_Comment_Repository;
            }
        }

        public ISQLInjection_User_MongoRepository SQLInjection_User_MongoRepository => throw new NotImplementedException();

        public void PushToDB()
        {
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    context.SaveChanges();
                    ts.Complete();
                }
                catch (Exception)
                {
                }
            }
        }
    }
}
