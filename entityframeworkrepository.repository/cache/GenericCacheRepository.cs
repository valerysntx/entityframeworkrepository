using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using entityframeworkrepository.cache;
using entityframeworkrepository.cache.Extentions;

namespace entityframeworkrepository.repository.cache
{

    /// <summary>
    /// GenericCacheRepository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericCacheRepository<T> : GenericDataRepository<T>, ICacheRepository<T> where T : class
    {

        public GenericCacheRepository(DbContext context) : base(context)
        {
        }

        public virtual IEnumerable<T> FromCache(IQueryable<T> dbQuery)
        {
            return dbQuery.FromCache((CachePolicy)CachePolicy.WithSlidingExpiration(TimeSpan.FromMinutes(10)));
        }

        public override IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            List<T> list;
            try
            {
                IQueryable<T> dbQuery = _entities.Set<T>();

                dbQuery = navigationProperties.Aggregate(dbQuery, (current, navigationProperty) => current.Include(navigationProperty));

                list = FromCache(ToQueryable(dbQuery)).ToList();
            }
            catch (SqlException ex)
            {
                throw new EntityException($"{typeof(T)} - {ex.Message}", ex);
            }

            return list;
        }

        public override IList<T> GetList(Func<T, bool> @where, params Expression<Func<T, object>>[] navigationProperties)
        {
            List<T> list;
            try
            {
                IQueryable<T> dbQuery = _entities.Set<T>();

                dbQuery = navigationProperties.Aggregate(dbQuery, (current, navigationProperty) => current.Include(navigationProperty));

                list = FromCache(ToQueryable(dbQuery).Where(@where).AsQueryable()).ToList();
            }
            catch (SqlException ex)
            {
                throw new EntityException($"{typeof(T)} - {ex.Message}", ex);
            }

            return list;
        }

        public override T GetSingle(Func<T, bool> @where, params Expression<Func<T, object>>[] navigationProperties)
        {
            T item = null;

            try
            {
                IQueryable<T> dbQuery = _entities.Set<T>();

                //Apply eager loading
                dbQuery = navigationProperties.Aggregate(dbQuery, (current, navigationProperty) => 
                                                                   current.Include(navigationProperty));

                item = FromCache(ToQueryable(dbQuery)).FirstOrDefault(where);

            }
            catch (SqlException ex)
            {
                throw new EntityException($"{typeof(T)} - {ex.Message}", ex);
            }

            return item;
        }

    }
}