using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;

using entityframeworkrepository.cache;
using entityframeworkrepository.repository;


namespace entityframeworkrepository.webapp.Repository
{
    public class DictionaryRepository : GenericDataRepository<Dictionary>
    {
        public DictionaryRepository(DbContext context, ICacheProvider provider = null) : base(context, provider)
        {
        }

        public override IList<Dictionary> GetPagedList(Func<Dictionary, bool> @where, int page = 0, int take = 1000, params Expression<Func<Dictionary, object>>[] navigationProperties)
        {
            return base.GetPagedList(@where, page, take, navigationProperties);
        }
    }
}