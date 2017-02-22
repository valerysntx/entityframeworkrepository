using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace entityframeworkrepository.core.repository
{
    /// <summary>
    /// Abstract class of CachedGenericRepository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TCache"></typeparam>
    // ReSharper disable once UnusedMember.Global
    public abstract class AbstractCachedGenericRepository<T, TCache> :
        IGenericDataRepository<T>
        where TCache : ICache<int, T>, new ()
        where T : BaseEntity
    {
        public abstract IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties);
        public abstract IList<T> GetList(Func<T, bool> @where, params Expression<Func<T, object>>[] navigationProperties);
        public abstract T GetSingle(Func<T, bool> @where, params Expression<Func<T, object>>[] navigationProperties);
        public abstract T Add(params T[] items);
        public abstract T Update(params T[] items);
        public abstract T Remove(params T[] items);
        public abstract void Save();
    }

}