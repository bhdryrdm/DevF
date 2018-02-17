using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DevF_LABS.Presentation.Redis
{
    public interface ICacheManager
    {
        T Get<T>(string key);
        void Set(string key, object data, int cacheTime);
        bool IsSet(string key);
        bool Remove(string key);
        void RemoveByPattern(string pattern);
        void Clear();
    }
}