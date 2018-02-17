using DevF_LABS.Data.Mongo;
using DevF_LABS.Repository.Mongo_DB_Repository.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevF_LABS.Repository.Mongo_DB_Repository.Repositories
{
    public class SQLInjection_User_MongoRepository : Mongo_BaseRepository<SQLInjection_User> , ISQLInjection_User_MongoRepository
    {
    }
}
