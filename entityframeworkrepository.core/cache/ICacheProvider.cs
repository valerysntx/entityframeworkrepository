using System.Collections.Generic;

namespace entityframeworkrepository.core.cache
{
    public interface ICacheProvider
    {


        object Get(string key);

        void Set(string key, object data, int cacheTime);

        bool IsSet(string key);

        void Invalidate(string key);
    }
}