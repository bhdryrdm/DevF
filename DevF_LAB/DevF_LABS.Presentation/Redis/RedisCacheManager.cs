using StackExchange.Redis;
using System;

namespace DevF_LABS.Presentation.Redis
{
    public class RedisCacheManager : CacheHelper, ICacheManager
    {
        private static IDatabase _db;
        private const string host = "127.0.0.1"; // Default Host Address
        private const int port = 6379; // Default Port

        private static RedisCacheManager singletonObject;
        private static Object lockControl = new Object();
        private static Object redislockControl = new Object();

        private RedisCacheManager()
        {
        }

        public static RedisCacheManager CreateRedisDatabase()
        {
            // Redis Database Singleton Design Pattern
            if(_db == null)
            {
                lock (redislockControl)
                {
                    if(_db == null)
                    {
                        _db = CreateRedisDB();
                    }
                }
            }

            // Redis Manager Object Singleton Design Pattern
            if(singletonObject == null)
            {
                lock (lockControl)
                {
                    if(singletonObject == null)
                    {
                        singletonObject = new RedisCacheManager();
                    }
                }
            }
            return singletonObject;
        }

        private static IDatabase CreateRedisDB()
        {
            if (null == _db)
            {
                ConfigurationOptions option = new ConfigurationOptions();
                option.Ssl = false;
                option.EndPoints.Add(host, port);
                var connect = ConnectionMultiplexer.Connect(option);
                _db = connect.GetDatabase();
            }

            return _db;
        }

        public void Clear()
        {
            var server = _db.Multiplexer.GetServer(host, port);
            foreach (var item in server.Keys())
                _db.KeyDelete(item);
        }

        public T Get<T>(string key)
        {
            var rValue = _db.SetMembers(key);
            if (rValue.Length == 0)
                return default(T);

            return Deserialize<T>(rValue.ToStringArray());
        }

        public int GetInt(string key)
        {
            var rValue = _db.SetMembers(key);

            return Deserialize(rValue.ToStringArray());
        }

        public bool IsSet(string key)
        {
            return _db.KeyExists(key);
        }

        public bool Remove(string key)
        {
            return _db.KeyDelete(key);
        }

        public bool RemoveByModel(string key, object data)
        {
            if (data == null)
                return false;

            var entryBytes = Serialize(data);
            _db.SetRemove(key, entryBytes);

            return true;
        }

        public void RemoveByPattern(string pattern)
        {
            var server = _db.Multiplexer.GetServer(host, port);
            foreach (var item in server.Keys(pattern: "*" + pattern + "*"))
                _db.KeyDelete(item);
        }

        public void Set(string key, object data, int cacheTime)
        {
            if (data == null)
                return;

            var entryBytes = Serialize(data);
            _db.SetAdd(key, entryBytes);

            var expiresIn = TimeSpan.FromMinutes(cacheTime);

            if (cacheTime > 0)
                _db.KeyExpire(key, expiresIn);
        }

        public void ListRightPush(string key, object data,int cacheTime)
        {
            if(data == null)
                return;

            var entryBytes = Serialize(data);
            _db.ListRightPush(key, entryBytes);

            var expiresIn = TimeSpan.FromMinutes(cacheTime);

            if (cacheTime > 0)
                _db.KeyExpire(key, expiresIn);

        }
    }
}