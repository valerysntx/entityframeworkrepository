using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entityframeworkrepository.core
{
  using System;
using System.Collections.Generic;

namespace Cache
    {
        //Implementation of ICache
        public class Cache<TKey, TValue> : ICache<TKey, TValue> where TKey : class
        {
            private readonly object _syncLock = new object();
            private IDictionary<TKey, TValue> _internalCache = new Dictionary<TKey, TValue>();

            public TValue this[TKey key]
            {
                get {
                    lock (_syncLock)
                    {
                        return !_internalCache.ContainsKey(key) ? default(TValue) : _internalCache[key];
                    }
                }
                set {
                    lock (_syncLock)
                    {
                        _internalCache[key] = value;
                    }
                }
            }

            public ICollection<TValue> GetAll()
            {
                lock (_syncLock)
                {
                    return _internalCache.Values;
                }
            }

            //TODO: Change input parameter to ICache
            public void SetAll(IDictionary<TKey, TValue> items)
            {
                if (items == null)
                {
                    throw new ArgumentNullException("items");
                }

                var cache = new Dictionary<TKey, TValue>();
                foreach (var item in items)
                {
                    cache[item.Key] = item.Value;
                }

                lock (_syncLock)
                {
                    _internalCache = cache;
                }
            }

            public bool ContainsKey(TKey key)
            {
                if (key == null)
                {
                    return false;
                }

                lock (_syncLock)
                {
                    return _internalCache.ContainsKey(key);
                }
            }

            public int Count
            {
                get {
                    lock (_syncLock)
                    {
                        return _internalCache.Count;
                    }
                }
            }

            public void Remove(TKey key)
            {
                lock (_syncLock)
                {
                    _internalCache.Remove(key);
                }
            }
        }
    }
}
