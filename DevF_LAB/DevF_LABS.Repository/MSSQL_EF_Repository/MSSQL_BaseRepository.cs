using DevF_LABS.Data.MSSQL.EntityFramework.CodeFirst;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity.Migrations;

namespace DevF_LABS.Repository.MSSQL_EF_Repository
{
    public class MSSQL_BaseRepository<T> : IRepository<T> , IDisposable where T : class
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public MSSQL_BaseRepository(MSSQL_EF_CF_Context context)
        {
            _dbContext = context;
            _dbSet = context.Set<T>();

        }

        public bool Create(T entity)
        {
            try
            {
                _dbSet.Add(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(T entity)
        {
            try
            {
                _dbSet.Remove(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public T GetByID(int ID)
        {
            return _dbSet.Find(ID);
        }

        public bool Update(T entity)
        {
            try
            {
                _dbSet.AddOrUpdate(entity);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }

            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
