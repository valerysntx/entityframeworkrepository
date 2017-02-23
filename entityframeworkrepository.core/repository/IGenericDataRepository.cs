using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using entityframeworkrepository.core.entity;

namespace entityframeworkrepository.core.repository
{
    public interface IGenericDataRepository<T> where T : BaseEntity
    {
        IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties);
        IList<T> GetList(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);
        T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties);
        T Add(params T[] items);
        T Update(params T[] items);
        T Remove(params T[] items);
        void Save();
    }
}