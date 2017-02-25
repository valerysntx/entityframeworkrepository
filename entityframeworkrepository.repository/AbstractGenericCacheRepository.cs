using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using entityframeworkrepository.core.entity;
using entityframeworkrepository.core.repository;

namespace entityframeworkrepository.repository
{
    /// <summary>
    /// AbstractGenericCacheRepository<typeparam name="T">Entity</typeparam>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class AbstractGenericCacheRepository<T> : IGenericCacheRepository<T> where T : class
    {
        /// <summary>
        /// Implement dbQuery
        /// </summary>
        /// <param name="dbQuery"></param>
        /// <returns></returns>
        public abstract IQueryable<T> ToQueryable(IQueryable<T> dbQuery);

        /// <summary>
        /// Implement cache
        /// </summary>
        /// <param name="dbQuery"></param>
        /// <returns></returns>
        public abstract IEnumerable<T> FromCache(IQueryable<T> dbQuery);

        public abstract IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties);
        public abstract IList<T> GetList(Func<T, bool> @where, params Expression<Func<T, object>>[] navigationProperties);
        public abstract T GetSingle(Func<T, bool> @where, params Expression<Func<T, object>>[] navigationProperties);
        public abstract T Add(params T[] items);
        public abstract T Update(params T[] items);
        public abstract T Remove(params T[] items);
        public abstract void Save();
    }
}