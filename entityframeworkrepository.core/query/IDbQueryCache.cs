using System.Collections.Generic;
using System.Linq;

namespace entityframeworkrepository.core.query
{
    public interface IDbQueryCache<T>: IDbQuery<T> where T : class
    {
        IEnumerable<T> FromCache(IQueryable<T> dbQuery);
    }
}