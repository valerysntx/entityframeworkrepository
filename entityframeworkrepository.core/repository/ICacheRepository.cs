using entityframeworkrepository.cache;
using entityframeworkrepository.core;
using entityframeworkrepository.core.query;

namespace entityframeworkrepository.core.repository
{
    /// <summary>
    /// ICacheRepository<typeparam name="T"> Entity </typeparam>
    /// </summary>

    public interface ICacheRepository<T>: IDbQueryCache<T> where T: class
    {
    }
}