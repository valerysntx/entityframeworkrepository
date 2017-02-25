using entityframeworkrepository.cache;
using entityframeworkrepository.core;

namespace entityframeworkrepository.core.repository
{
    public interface ICacheRepository
    {
        ICacheProvider CacheProvider { get; }
    }
}