using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;

using entityframeworkrepository.cache;
using entityframeworkrepository.cache.Extentions;
using entityframeworkrepository.core.entity;
using entityframeworkrepository.core.query;
using entityframeworkrepository.core.repository;

namespace entityframeworkrepository.repository
{
    /// <summary>
    /// Generic Data Repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public partial class GenericDataRepository<T> : IGenericDataRepository<T> where T : class
    {
        protected DbContext _entities;
        protected readonly IDbSet<T> _dbset;

        /// <summary>
        /// default ctor
        /// </summary>
        /// <param name="context"></param>
        public GenericDataRepository(DbContext context)
        {
            if (context == null) throw new ArgumentNullException("@context");
            _entities = context;
            _dbset = context.Set<T>();
        }


        /// <summary>
        /// GetAll
        /// </summary>
        /// <param name="navigationProperties"></param>
        /// <returns></returns>
        public virtual IList<T> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            List<T> list;
            try
            {
                    IQueryable<T> dbQuery = _entities.Set<T>();

                    dbQuery = navigationProperties.Aggregate(dbQuery, (current, navigationProperty) => current.Include(navigationProperty));

                    list = ToQueryable(dbQuery).ToList();
            }
            catch (SqlException ex)
            {
                throw new EntityException(string.Format("{0} - {1}", typeof (T), ex.Message), ex);
            }

            return list;
        }

        /// <summary>
        ///  Database Query Abstraction
        /// </summary>
        /// <param name="dbQuery"></param>
        /// <returns></returns>
        public IQueryable<T> ToQueryable(IQueryable<T> dbQuery)
        {
            return dbQuery.AsQueryable().AsNoTracking();
        }

        /// <summary>
        ///GetList
        /// </summary>
        /// <param name="where"></param>
        /// <param name="navigationProperties"></param>
        /// <returns></returns>
        public virtual IList<T> GetList(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            List<T> list;
            try
            {
                    IQueryable<T> dbQuery = _entities.Set<T>();

                    //EAGERLY
                    dbQuery = navigationProperties.Aggregate(dbQuery, (current, navigationProperty) => current.Include(navigationProperty));

                    list = ToQueryable(dbQuery).Where(where).ToList();
            }
            catch (SqlException ex)
            {
                throw new EntityException(string.Format("{0} - {1}", typeof (T), ex.Message), ex);
            }

            return list;
        }


        /// <summary>
        /// Paged list
        /// </summary>
        /// <param name="where"></param>
        /// <param name="page"></param>
        /// <param name="take"></param>
        /// <param name="navigationProperties"></param>
        /// <returns></returns>
       public virtual IList<T> GetPagedList(Func<T, bool> where, int page = 0, int take = 1000, params Expression<Func<T, object>>[] navigationProperties)
       {
           return GetList(where, navigationProperties).Skip(page * take).Take(take).ToList();
       }

       public virtual T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties)
       {
            T item = null;

            try
            {
                IQueryable<T> dbQuery = _entities.Set<T>();

                //Apply eager loading
                dbQuery = navigationProperties.Aggregate(dbQuery, (current, navigationProperty) => current.Include(navigationProperty));

                item = ToQueryable(dbQuery).FirstOrDefault(where);

            } catch (SqlException ex)
            {
                throw new EntityException(string.Format("{0} - {1}", typeof (T), ex.Message), ex);
            }

            return item;
        }

       public virtual T Add(params T[] items)
       {
           return Update(items);
       }

        public virtual T Update(params T[] items)
        {
            T last = null;
            try
            {
                    var dbSet = _entities.Set<T>();
                    foreach (var item in items)
                    {
                        last = dbSet.Add(item);

                        foreach (var entry in _entities.ChangeTracker.Entries<IAuditableEntity>())
                        {
                            var entity = entry.Entity;
                            entry.State = GetEntityState(entry.State);
                            if (entry.State == EntityState.Added)
                            {
                                entry.Entity.CreatedDate = DateTime.Now;
                                entry.Entity.UpdatedDate = DateTime.Now;
                            }
                            if (entry.State == EntityState.Modified)
                            {
                                entry.Entity.UpdatedDate = DateTime.Now;
                            }
                        }
                    }

                Save();
            }
            catch (SqlException ex)
            {
                throw new EntityException(string.Format("{0} - {1}", typeof(T), ex.Message), ex);
            }

            return last;
        }

        public T Remove(params T[] items)
        {
            Update(items);
            return null;
        }

        public void Save()
        {
            _entities.SaveChanges();
        }

        public T Attach(T entity)
        {
            return _entities.Set<T>().Attach(entity);
        }


        protected static EntityState GetEntityState(EntityState entityState)
        {
            return entityState;
        }

    }
}