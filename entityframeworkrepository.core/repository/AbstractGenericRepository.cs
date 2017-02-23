using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using entityframeworkrepository.core.cache;
using entityframeworkrepository.core.entity;

namespace entityframeworkrepository.core.repository
{
    /// <summary>
    /// abstract
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class AbstractGenericRepository<T> : IGenericDataRepository<T> where T : BaseEntity
    {
        protected AbstractGenericRepository()
        {
        }

        public abstract IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties);
        public abstract IList<T> GetList(Func<T, bool> @where, params Expression<Func<T, object>>[] navigationProperties);
        public abstract T GetSingle(Func<T, bool> @where, params Expression<Func<T, object>>[] navigationProperties);
        public abstract T Add(params T[] items);
        public abstract T Update(params T[] items);
        public abstract T Remove(params T[] items);
        public abstract void Save();
    }

}