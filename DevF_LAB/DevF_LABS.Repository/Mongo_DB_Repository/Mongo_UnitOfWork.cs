using DevF_LABS.Repository.Mongo_DB_Repository.IRepositories;
using DevF_LABS.Repository.MSSQL_EF_Repository.IRepositories;
using System;

namespace DevF_LABS.Repository.Mongo_DB_Repository
{
    public class Mongo_UnitOfWork : IUnitOfWork
    {
        public ISQLInjection_User_Repository SQLInjection_User_Repository => throw new NotImplementedException();

        public IXSS_Comment_Repository XSS_Comment_Repository => throw new NotImplementedException();

        public ISQLInjection_User_MongoRepository SQLInjection_User_MongoRepository { get; }

        public void PushToDB()
        {
            throw new NotImplementedException();
        }
    }
}
