using DevF_LABS.Data.Mongo;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DevF_LABS.Repository
{
    public interface IMongoRepository<T>  where T : MongoEntityBase
    {

        IList<T> GetAll();
        IList<T> GetAll(Expression<Func<T, bool>> predicate);
        T GetByID(string ID);

        WriteConcernResult Create(T entity);
        WriteConcernResult Update(T entity);
        WriteConcernResult Delete(T entity);
    }
}
