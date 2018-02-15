using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using entityframeworkrepository.core.entity;
using entityframeworkrepository.core.query;

// ReSharper disable once CheckNamespace
namespace entityframeworkrepository.repository
{
    public interface IGenericDataRepository<T>: IDbQuery<T> where T : class
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