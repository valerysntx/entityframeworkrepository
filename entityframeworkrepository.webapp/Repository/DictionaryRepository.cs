using System.Data.Entity;
using entityframeworkrepository.core.cache;
using entityframeworkrepository.core.repository;

namespace entityframeworkrepository.webapp.Repository
{
    public class DictionaryRepository : GenericDataRepository<Dictionary>
    {
        public DictionaryRepository(DbContext context, ICacheProvider provider = null) : base(context, provider)
        {
        }
    }
}