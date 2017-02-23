using System.Collections.Generic;

namespace entityframeworkrepository.core.cache
{
    /// <summary>
    /// Generic cache. Should be wrapped in a singelton.
    ///     - Some issues with reloading, see http://stackoverflow.com/questions/8403782/c-sharp-reload-singleton-cache/ for more info.
    /// </summary>
    /// <typeparam name="TKey">The type of the key.</typeparam>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    public interface ICache<TKey, TValue>
    {
        /// <summary>
        /// Gets or sets the <see cref="TValue"/> with the specified key.
        /// </summary>
        TValue this[TKey key] { get; set; }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        ICollection<TValue> GetAll();

        /// <summary>
        /// Replace current items in cache with the new items.
        /// </summary>
        /// <param name="items">The cached items.</param>
        void SetAll(IDictionary<TKey, TValue> items);

        /// <summary>
        /// Remove key and data from cache.
        /// </summary>
        void Remove(TKey key);

        /// <summary>
        /// Determines whether the specified key exists.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>
        ///   <c>true</c> if the specified key contains key; otherwise, <c>false</c>.
        /// </returns>
        bool ContainsKey(TKey key);

        /// <summary>
        /// Gets the number of elements contained in the <see cref="ICollection{TValue}"/>
        /// </summary>
        int Count { get; }
    }
}