using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace entityframeworkrepository.cache
{
    /// <summary>
    /// An <see langword="interface"/> defining a cache provider.
    /// </summary>
    public interface ICacheProvider
    {
        /// <summary>
        /// Inserts a cache entry into the cache without overwriting any existing cache entry.
        /// </summary>
        /// <param name="cacheKey">A unique identifier for the cache entry.</param>
        /// <param name="value">The object to insert.</param>
        /// <param name="cachePolicy">An object that contains eviction details for the cache entry.</param>
        /// <returns>
        ///   <c>true</c> if insertion succeeded, or <c>false</c> if there is an already an entry in the cache that has the same key as key.
        /// </returns>
        bool Add(ICacheKey cacheKey, object value, ICachePolicy cachePolicy);

        /// <summary>
        /// Gets the cache value for the specified key
        /// </summary>
        /// <param name="cacheKey">A unique identifier for the cache entry.</param>
        /// <returns>The cache value for the specified key, if the entry exists; otherwise, <see langword="null"/>.</returns>
        object Get(ICacheKey cacheKey);

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
        object GetOrAdd(ICacheKey cacheKey, Func<ICacheKey, object> valueFactory, ICachePolicy cachePolicy);

#if NET45
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
        Task<object> GetOrAddAsync(CacheKey cacheKey, Func<CacheKey, Task<object>> valueFactory, CachePolicy cachePolicy);
#endif

        /// <summary>
        /// Removes a cache entry from the cache.
        /// </summary>
        /// <param name="cacheKey">A unique identifier for the cache entry.</param>
        /// <returns>If the entry is found in the cache, the removed cache entry; otherwise, <see langword="null"/>.</returns>
        object Remove(ICacheKey cacheKey);

        /// <summary>
        /// Expires the specified cache tag.
        /// </summary>
        /// <param name="cacheTag">The cache tag.</param>
        /// <returns>The number of items expired.</returns>
        int Expire(ICacheTag cacheTag);

        /// <summary>
        /// Inserts a cache entry into the cache overwriting any existing cache entry.
        /// </summary>
        /// <param name="cacheKey">A unique identifier for the cache entry.</param>
        /// <param name="value">The object to insert.</param>
        /// <param name="cachePolicy">A <see cref="CachePolicy"/> that contains eviction details for the cache entry.</param>
        bool Set(ICacheKey cacheKey, object value, ICachePolicy cachePolicy);

        /// <summary>
        /// Clears all entries from the cache
        /// </summary>
        /// <returns>The number of items removed.</returns>
        long ClearCache();
    }
}
