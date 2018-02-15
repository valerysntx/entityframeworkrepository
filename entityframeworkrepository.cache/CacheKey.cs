using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace entityframeworkrepository.cache
{
    /// <summary>
    /// A class representing a unique key for cache items.
    /// </summary>
    public class CacheKey : ICacheKey
    {
        private readonly string _key;
        private readonly HashSet<ICacheTag> _tags;

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheKey"/> class.
        /// </summary>
        /// <param name="key">The key for a cache item.</param>
        public CacheKey(string key): this(key, Enumerable.Empty<string>()){
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CacheKey"/> class.
        /// </summary>
        /// <param name="key">The key for a cache item.</param>
        /// <param name="tags">The tags for the cache item.</param>
        public CacheKey(string key, IEnumerable<string> tags)
        {
            if (tags == null)
                throw new ArgumentNullException(nameof(tags));

            _key = key ?? throw new ArgumentNullException(nameof(key));

            var cacheTags = tags.Select(k => new CacheTag(k));
            _tags = new HashSet<ICacheTag>(cacheTags);
        }


        /// <summary>
        /// Gets the key for a cached item.
        /// </summary>
        public string Key
        {
            get { return _key; }
        }

        /// <summary>
        /// Gets the tags for a cached item.
        /// </summary>
        public HashSet<ICacheTag> Tags
        {
            get { return _tags; }
        }

        HashSet<ICacheTag> ICacheKey.Tags
        {
            get { return new HashSet<ICacheTag>(_tags); }
        }
    }
}
