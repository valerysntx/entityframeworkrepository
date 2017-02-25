using System.Linq;

namespace entityframeworkrepository.core.query
{
    public interface IDbQuery<T> where T : class
    {
        IQueryable<T> ToQueryable(IQueryable<T> dbQuery);
    }
}