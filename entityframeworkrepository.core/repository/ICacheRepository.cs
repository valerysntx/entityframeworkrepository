
using entityframeworkrepository.core.query;

namespace entityframeworkrepository.repository.cache
{
    /// <summary>
    /// ICacheRepository<typeparam name="T"> Entity </typeparam>
    /// </summary>

    public interface ICacheRepository<T>: IDbQueryCache<T> where T: class
    {
    }
}