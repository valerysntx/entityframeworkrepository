namespace entityframeworkrepository.core.repository
{
    /// <summary>
    /// IGenericCacheRepository
    /// </summary>
    /// <typeparam name="T">Entity</typeparam>
    public interface IGenericCacheRepository<T> : ICacheRepository<T>, IGenericDataRepository<T> where T : class
    {
    }
}