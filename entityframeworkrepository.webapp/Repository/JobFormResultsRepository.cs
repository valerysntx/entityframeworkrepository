using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using entityframeworkrepository.cache.Extentions;
using entityframeworkrepository.repository;

namespace entityframeworkrepository.webapp.Repository
{
    public class JobFormResultsRepository : GenericDataRepository<JobFormResultsView>
    {
        public JobFormResultsRepository(DbContext context) : base(context)
        {
        }

        public IList<JobFormResultsView> GetOrderedList(Func<JobFormResultsView, bool> where,
            Expression<Func<JobFormResultsView,object>>[] navExpressions,
            params Expression<Func<JobFormResultsView, object>>[] props)
        {
            return GetList(where, navExpressions).AsEnumerable().OrderBy(props.ToArray()).ToList();
        }
    }
}