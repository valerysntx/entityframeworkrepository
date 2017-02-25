using System.Collections.Generic;
// ReSharper disable CheckNamespace

namespace entityframeworkrepository.cache
{
    public interface ICacheKey
    {
        string Key { get; }
        HashSet<ICacheTag> Tags { get; }
    }
}