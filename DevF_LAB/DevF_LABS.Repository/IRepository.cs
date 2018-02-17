using System;
using System.Linq;
using System.Linq.Expressions;

namespace DevF_LABS.Repository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate);
        T GetByID(int ID);

        bool Create(T entity);
        bool Update(T entity);
        bool Delete(T entity);
    }
}
