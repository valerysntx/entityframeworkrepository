using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using entityframeworkrepository.core.cache;
using entityframeworkrepository.core.entity;
using entityframeworkrepository.core.unitofwork;

namespace entityframeworkrepository.core.repository
{

    public partial class GenericDataRepository<T> : IGenericDataRepository<T> where T : BaseEntity
    {
        protected DbContext _entities;
        protected readonly IDbSet<T> _dbset;
        protected ICacheProvider _cacheProvider;

        /// <summary>
        /// default ctor
        /// </summary>
        /// <param name="context"></param>
        public GenericDataRepository(DbContext context, ICacheProvider provider = null)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            _entities = context;
            _cacheProvider = provider ?? new DefaultCacheProvider();
            _dbset = context?.Set<T>();
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

                    IQueryable<T> dbQuery = _entities?.Set<T>();

                    dbQuery = navigationProperties.Aggregate(dbQuery, (current, navigationProperty) => current.Include(navigationProperty));

                    list = dbQuery.AsNoTracking().ToList();
            }
            catch (SqlException ex)
            {
                throw new EntityException($"{typeof (T)} - {ex.Message}", ex);
            }

            return list;
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
                    IQueryable<T> dbQuery = _entities?.Set<T>();

                    //EAGERLY
                    dbQuery = navigationProperties.Aggregate(dbQuery, (current, navigationProperty) => current.Include(navigationProperty));

                    list = dbQuery.AsNoTracking().Where(where).ToList();
            }
            catch (SqlException ex)
            {
                throw new EntityException($"{typeof (T)} - {ex.Message}", ex);
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
           return GetList(where, navigationProperties)
                  .Skip(page * take).Take(take)
                  .ToList();

       }

       public virtual T GetSingle(Func<T, bool> where, params Expression<Func<T, object>>[] navigationProperties)
       {
            T item = null;

            try
            {
                IQueryable<T> dbQuery = _entities?.Set<T>();

                //Apply eager loading
                dbQuery = navigationProperties.Aggregate(dbQuery, (current, navigationProperty) => current.Include(navigationProperty));

                item = dbQuery.AsNoTracking().FirstOrDefault(where);


            } catch (SqlException ex)
            {
                throw new EntityException($"{typeof (T)} - {ex.Message}", ex);
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
                    var dbSet = _entities?.Set<T>();
                    foreach (var item in items)
                    {
                        last = dbSet.Add(item);
                        foreach (var entry in _entities?.ChangeTracker?.Entries<IAuditableEntity>())
                        {
                            var entity = entry?.Entity;
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
                throw new EntityException($"{typeof (T)} - {ex.Message}", ex);
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
            _entities?.SaveChanges();
        }

        public T Attach(T entity)
        {
            return _entities?.Set<T>()?.Attach(entity);
        }


        protected static EntityState GetEntityState(EntityState entityState)
        {
            return entityState;
        }

    }
}