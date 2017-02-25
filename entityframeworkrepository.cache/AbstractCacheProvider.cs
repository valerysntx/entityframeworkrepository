using System;

namespace entityframeworkrepository.cache
{
    /// <summary>
    /// abstract CacheProvider
    /// </summary>
    public abstract class AbstractCacheProvider : ICacheProvider
    {
        public abstract bool Add(ICacheKey cacheKey, object value, ICachePolicy cachePolicy);
        public abstract object Get(ICacheKey cacheKey);
        public abstract object Remove(ICacheKey cacheKey);
        public abstract int Expire(ICacheTag cacheTag);
        public abstract long ClearCache();
        public abstract bool Set(ICacheKey cacheKey, object value, ICachePolicy cachePolicy);
        public abstract object GetOrAdd(ICacheKey cacheKey, Func<ICacheKey, object> valueFactory, ICachePolicy cachePolicy);
    }
}