using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Caching;
using System.Runtime.Caching.Generic;
using System.Threading.Tasks;

namespace entityframeworkrepository.cache
{
    /// <summary>
    /// A cache provider based on <see cref="MemoryCache"/>.
    /// </summary>
    public class MemoryCacheProvider : AbstractCacheProvider
    {
        private const string _tagKey = "global::tag::{0}";

        /// <summary>
        /// Inserts a cache entry into the cache without overwriting any existing cache entry.
        /// </summary>
        /// <param name="cacheKey">A unique identifier for the cache entry.</param>
        /// <param name="value">The object to insert.</param>
        /// <param name="cachePolicy">An object that contains eviction details for the cache entry.</param>
        /// <returns>
        ///   <c>true</c> if insertion succeeded, or <c>false</c> if there is an already an entry in the cache that has the same key as key.
        /// </returns>
        public override bool Add(ICacheKey cacheKey, object value, ICachePolicy cachePolicy)
        {
            string key = GetKey(cacheKey);
            var item = new CacheItem(key, value);
            var policy = CreatePolicy(cacheKey, cachePolicy);

            var existing = MemoryCache.Default.AddOrGetExisting(item, policy);
            return existing.Value == null;
        }

        /// <summary>
        /// Gets the cache value for the specified key
        /// </summary>
        /// <param name="cacheKey">A unique identifier for the cache entry.</param>
        /// <returns>
        /// The cache value for the specified key, if the entry exists; otherwise, <see langword="null"/>.
        /// </returns>
        public override object Get(ICacheKey cacheKey)
        {
            string key = GetKey(cacheKey);
            return MemoryCache.Default.Get(key);
        }

        /// <summary>
        /// Gets the cache value for the specified key that is already in the dictionary or the new value for the key as returned by <paramref name="valueFactory"/>.
        /// </summary>
        /// <param name="cacheKey">A unique identifier for the cache entry.</param>
        /// <param name="valueFactory">The function used to generate a value to insert into cache.</param>
        /// <param name="cachePolicy">A <see cref="CachePolicy"/> that contains eviction details for the cache entry.</param>
        /// <returns>
        /// The value for the key. This will be either the existing value for the key if the key is already in the cache,
        /// or the new value for the key as returned by <paramref name="valueFactory"/> if the key was not in the cache.
        /// </returns>
        public override object GetOrAdd(ICacheKey cacheKey, Func<ICacheKey, object> valueFactory, ICachePolicy cachePolicy)
        {

            var key = GetKey(cacheKey);
            var cachedResult = MemoryCache.Default.Get(key);

            if (cachedResult != null)
            {
                Debug.WriteLine("Cache Hit : " + key);
                return cachedResult;
            }

            Debug.WriteLine("Cache Miss: " + key);

            // get value and add to cache, not bothered
            // if it succeeds or not just rerturn the value
            var value = valueFactory(cacheKey);
            this.Add(cacheKey, value, cachePolicy);

            return value;
        }


        /// <summary>
        /// Gets the cache value for the specified key that is already in the dictionary or the new value for the key as returned asynchronously by <paramref name="valueFactory"/>.
        /// </summary>
        /// <param name="cacheKey">A unique identifier for the cache entry.</param>
        /// <param name="valueFactory">The asynchronous function used to generate a value to insert into cache.</param>
        /// <param name="cachePolicy">A <see cref="CachePolicy"/> that contains eviction details for the cache entry.</param>
        /// <returns>
        /// The value for the key. This will be either the existing value for the key if the key is already in the cache,
        /// or the new value for the key as returned by <paramref name="valueFactory"/> if the key was not in the cache.
        /// </returns>
        public async Task<object> GetOrAddAsync(ICacheKey cacheKey, Func<ICacheKey, Task<object>> valueFactory, ICachePolicy cachePolicy)
        {
            var key = GetKey(cacheKey);
            var cachedResult = MemoryCache.Default.Get(key);

            if (cachedResult != null)
            {
                Debug.WriteLine("Cache Hit : " + key);
                return cachedResult;
            }

            Debug.WriteLine("Cache Miss: " + key);

            // get value and add to cache, not bothered
            // if it succeeds or not just rerturn the value
            var value = await valueFactory(cacheKey).ConfigureAwait(false);
            this.Add(cacheKey, value, cachePolicy);

            return value;
        }


        /// <summary>
        /// Removes a cache entry from the cache.
        /// </summary>
        /// <param name="cacheKey">A unique identifier for the cache entry.</param>
        /// <returns>
        /// If the entry is found in the cache, the removed cache entry; otherwise, <see langword="null"/>.
        /// </returns>
        public override object Remove(ICacheKey cacheKey)
        {
            string key = GetKey(cacheKey);
            return MemoryCache.Default.Remove(key);
        }

        /// <summary>
        /// Expires the specified cache tag.
        /// </summary>
        /// <param name="cacheTag">The cache tag.</param>
        /// <returns>
        /// The number of items expired.
        /// </returns>
        public override int Expire(ICacheTag cacheTag)
        {
            string key = GetTagKey(cacheTag);
            var item = new CacheItem(key, DateTimeOffset.UtcNow.Ticks);
            var policy = new CacheItemPolicy { AbsoluteExpiration = ObjectCache.InfiniteAbsoluteExpiration };

            MemoryCache.Default.Set(item, policy);
            return 0;
        }

        /// <summary>
        /// Inserts a cache entry into the cache overwriting any existing cache entry.
        /// </summary>
        /// <param name="cacheKey">A unique identifier for the cache entry.</param>
        /// <param name="value">The object to insert.</param>
        /// <param name="cachePolicy">A <see cref="CachePolicy"/> that contains eviction details for the cache entry.</param>
        /// <returns></returns>
        public override bool Set(ICacheKey cacheKey, object value, ICachePolicy cachePolicy)
        {
            string key = GetKey(cacheKey);
            var item = new CacheItem(key, value);
            var policy = CreatePolicy(cacheKey, cachePolicy);

            MemoryCache.Default.Set(item, policy);
            return true;
        }

        /// <summary>
        /// Clears all entries from the cache
        /// </summary>
        /// <returns></returns>
        public override long ClearCache()
        {
            return MemoryCache.Default.Trim(100);
        }


        // internal for testing
        /// <summary>
        /// GetKey as a string
        /// </summary>
        /// <param name="cacheKey"></param>
        /// <returns></returns>
        public static string GetKey(ICacheKey cacheKey)
        {
            return cacheKey.Key;
        }

        public static string GetTagKey(ICacheTag t)
        {
            return string.Format(_tagKey, t);
        }

        public static CacheItemPolicy CreatePolicy(ICacheKey key, ICachePolicy cachePolicy)
        {
            var policy = new CacheItemPolicy();

            switch (cachePolicy.Mode)
            {
                case CacheExpirationMode.Sliding:
                    policy.SlidingExpiration = cachePolicy.SlidingExpiration;
                    break;
                case CacheExpirationMode.Absolute:
                    policy.AbsoluteExpiration = cachePolicy.AbsoluteExpiration;
                    break;
                case CacheExpirationMode.Duration:
                    policy.AbsoluteExpiration = DateTimeOffset.Now.Add(cachePolicy.Duration);
                    break;
                default:
                    policy.AbsoluteExpiration = ObjectCache.InfiniteAbsoluteExpiration;
                    break;
            }

            var changeMonitor = CreateChangeMonitor(key);
            if (changeMonitor != null)
                policy.ChangeMonitors.Add(changeMonitor);

            return policy;
        }

        public static CacheEntryChangeMonitor CreateChangeMonitor(ICacheKey key)
        {
            var cache = MemoryCache.Default;

            var tags = key.Tags.Select(GetTagKey).ToList();

            if (tags.Count == 0) return null;

            // make sure tags exist
            foreach (string tag in tags)
                cache.AddOrGetExisting(tag, DateTimeOffset.UtcNow.Ticks, ObjectCache.InfiniteAbsoluteExpiration);

            return cache.CreateCacheEntryChangeMonitor(tags);
        }
    }
}