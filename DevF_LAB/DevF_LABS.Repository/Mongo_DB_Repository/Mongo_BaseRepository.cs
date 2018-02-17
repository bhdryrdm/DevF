using DevF_LABS.Data.Mongo;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Linq.Expressions;

namespace DevF_LABS.Repository.Mongo_DB_Repository
{
    public class Mongo_BaseRepository<T> : IMongoRepository<T> where T : MongoEntityBase
    {
        private MongoDatabase database;
        private MongoCollection<T> collection;

        public Mongo_BaseRepository()
        {
            GetDatabase();
            GetCollection();
        }


        public IList<T> GetAll()
        {
            return collection.FindAllAs<T>().ToList();
        }

        public IList<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return collection.AsQueryable<T>().Where(predicate.Compile()).ToList();
        }

        public T GetByID(string ID)
        {
            return collection.FindOneByIdAs<T>(ID);
        }

        public WriteConcernResult Create(T entity)
        {
            entity.ID = ObjectId.GenerateNewId().ToString();
            return collection.Insert(entity);
        }

        public WriteConcernResult Update(T entity)
        {
            throw new NotImplementedException();
        }

        public WriteConcernResult Delete(T entity)
        {
            return collection.Remove(Query.EQ("_id", entity.ID));
        }

        #region Private Helper Methods
        private void GetDatabase()
        {
            var client = new MongoClient(GetConnectionString());
            var server = client.GetServer();
            database = server.GetDatabase(GetDatabaseName());
        }
        private string GetConnectionString()
        {
            return ConfigurationManager.AppSettings.Get("MongoDbConnectionString").Replace("{DB_NAME}", GetDatabaseName());
        }
        private string GetDatabaseName()
        {
            return ConfigurationManager.AppSettings.Get("MongoDbDatabaseName");
        }
        private void GetCollection()
        {
            collection = database.GetCollection<T>(typeof(T).Name);
        }
        #endregion
    }
}
