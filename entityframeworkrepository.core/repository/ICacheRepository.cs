using entityframeworkrepository.core.cache;

namespace entityframeworkrepository.core.repository
{
    public interface ICacheRepository
    {
        ICacheProvider CacheProvider { get; }
    }
}