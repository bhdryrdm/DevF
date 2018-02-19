using DevF_LABS.Data.MSSQL.EntityFramework.CodeFirst;
using DevF_LABS.Data.MSSQL.EntityFramework.CodeFirst.Tables;
using Enyim.Caching;
using Enyim.Caching.Configuration;
using Enyim.Caching.Memcached;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DevF_LABS.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateDB()
        {
            try
            {
                //PK olarak işaretlenmiş 1 artır
                Settings settigns = new Settings { ID = 2 };
                using (var dbContext = new MSSQL_EF_CF_Context())
                {
                    dbContext.Settings.Add(settigns);
                    dbContext.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
        
        [TestMethod]
        public void Memcache()
        {
            CreateMemcache("mobil", "05469540686");
            GetMemcacheValue("bhdr");

            CreateMemcache("bhdr", "0 3600 6 %0d%0a hacked %0d%0a");
            GetMemcacheValue("bhdr");

        }

        public void CreateMemcache(string key , string value)
        {
            MemcachedClientConfiguration config = new MemcachedClientConfiguration();
            config.AddServer("127.0.0.1", 11211);
            config.Protocol = MemcachedProtocol.Binary;
            MemcachedClient client = new MemcachedClient(config);

            bool result = client.Store(StoreMode.Set, key, value);
            
            
        }

        public void GetMemcacheValue(string key)
        {
            MemcachedClientConfiguration config = new MemcachedClientConfiguration();
            config.AddServer("127.0.0.1", 11211);
            config.Protocol = MemcachedProtocol.Binary;
            MemcachedClient client = new MemcachedClient(config);

            object result = client.Get(key);
            
        }


    }
}
