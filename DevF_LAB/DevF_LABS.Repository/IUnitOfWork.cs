using DevF_LABS.Repository.Mongo_DB_Repository.IRepositories;
using DevF_LABS.Repository.MSSQL_EF_Repository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevF_LABS.Repository
{
    public interface IUnitOfWork
    {
        ISQLInjection_User_Repository SQLInjection_User_Repository { get; }
        IXSS_Comment_Repository XSS_Comment_Repository { get; }





        ISQLInjection_User_MongoRepository SQLInjection_User_MongoRepository { get; }


        void PushToDB();
    }
}
