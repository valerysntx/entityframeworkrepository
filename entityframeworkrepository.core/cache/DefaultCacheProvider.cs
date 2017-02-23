using System;
using System.Collections.Generic;
using System.Runtime.Caching;

namespace entityframeworkrepository.core.cache
{
    public class DefaultCacheProvider : ICacheProvider
    {
        protected ObjectCache Cache { get { return MemoryCache.Default; } }

        public object Get(string key)
        {
            return Cache[key];
        }

        public void Set(string key, object data, int cacheTime)
        {
            CacheItemPolicy policy = new CacheItemPolicy() { AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(cacheTime) };

            if (IsSet(key)) return;

            Cache.Add(new CacheItem(key, data), policy);
        }

        public bool IsSet(string key)
        {
            return Cache[key] != null;
        }

        public void Invalidate(string key)
        {
            Cache.Remove(key);
        }
    }
}
