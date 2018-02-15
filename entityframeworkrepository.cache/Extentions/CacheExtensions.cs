using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using entityframeworkrepository.cache.Query;

namespace entityframeworkrepository.cache.Extentions
{
    /// <summary>
    /// Extension methods for query cache.
    /// </summary>
    public static class CacheExtensions
    {
        /// <summary>
        /// Returns the result of the <paramref name="query"/>; if possible from the cache,
        /// otherwise the query is materialized and the result cached before being returned.
        /// </summary>
        /// <typeparam name="TEntity">The type of the data in the data source.</typeparam>
        /// <param name="query">The query to be materialized.</param>
        /// <param name="cachePolicy">The cache policy for the query.</param>
        /// <param name="tags">The list of tags to use for cache expiration.</param>
        /// <returns>
        /// The result of the query.
        /// </returns>
        public static IEnumerable<TEntity> FromCache<TEntity>(this IQueryable<TEntity> query, CachePolicy cachePolicy = null, IEnumerable<string> tags = null)
            where TEntity : class
        {
            string key = query.GetCacheKey();
            var cacheKey = new CacheKey(key,
                tags ?? Enumerable.Empty<string>());

            // allow override of CacheManager
            var manager = Locator.Current.Resolve<CacheManager>();

            var result = manager.GetOrAdd( cacheKey, k => query.AsNoTracking().ToList(), cachePolicy ?? CachePolicy.Default) as IEnumerable<TEntity>;

            return result;
        }

#if NET45
        /// <summary>
        /// Returns the result of the <paramref name="query"/>; if possible from the cache,
        /// otherwise the query is materialized asynchronously and the result cached before being returned.
        /// </summary>
        /// <typeparam name="TEntity">The type of the data in the data source.</typeparam>
        /// <param name="query">The query to be materialized.</param>
        /// <param name="cachePolicy">The cache policy for the query.</param>
        /// <param name="tags">The list of tags to use for cache expiration.</param>
        /// <returns>
        /// The result of the query.
        /// </returns>
        public static async Task<IEnumerable<TEntity>> FromCacheAsync<TEntity>(this IQueryable<TEntity> query, CachePolicy cachePolicy = null, IEnumerable<string> tags = null)
            where TEntity : class
        {
            string key = query.GetCacheKey();
            var cacheKey = new CacheKey(key,
                tags ?? Enumerable.Empty<string>());

            // allow override of CacheManager
            var manager = Locator.Current.Resolve<CacheManager>();

            var result = await manager
                .GetOrAddAsync(
                    cacheKey,
                    async k => await query.AsNoTracking().ToListAsync().ConfigureAwait(false),
                    cachePolicy ?? CachePolicy.Default
                )
                .ConfigureAwait(false) as IEnumerable<TEntity>;

            return result;
        }

#endif

        /// <summary>
        /// Returns the first element of the <paramref name="query"/>; if possible from the cache,
        /// otherwise the query is materialized and the result cached before being returned.
        /// </summary>
        /// <typeparam name="TEntity">The type of the data in the data source.</typeparam>
        /// <param name="query">The query to be materialized.</param>
        /// <param name="cachePolicy">The cache policy for the query.</param>
        /// <param name="tags">The list of tags to use for cache expiration.</param>
        /// <returns>default(T) if source is empty; otherwise, the first element in source.</returns>
        public static TEntity FromCacheFirstOrDefault<TEntity>(this IQueryable<TEntity> query, CachePolicy cachePolicy = null, IEnumerable<string> tags = null)
            where TEntity : class
        {
            // ReSharper disable once PossibleUnintendedQueryableAsEnumerable
            return query.Take(1).FromCache(cachePolicy, tags).FirstOrDefault();
        }

#if NET45
        /// <summary>
        /// Returns the first element of the <paramref name="query"/>; if possible from the cache,
        /// otherwise the query is materialized asynchronously and the result cached before being returned.
        /// </summary>
        /// <typeparam name="TEntity">The type of the data in the data source.</typeparam>
        /// <param name="query">The query to be materialized.</param>
        /// <param name="cachePolicy">The cache policy for the query.</param>
        /// <param name="tags">The list of tags to use for cache expiration.</param>
        /// <returns>default(T) if source is empty; otherwise, the first element in source.</returns>
        public static async Task<TEntity> FromCacheFirstOrDefaultAsync<TEntity>(this IQueryable<TEntity> query, CachePolicy cachePolicy = null, IEnumerable<string> tags = null)
            where TEntity : class
        {
            var q = await query
                .Take(1)
                .FromCacheAsync(cachePolicy, tags)
                .ConfigureAwait(false);

            return q.FirstOrDefault();
        }

#endif

        /// <summary>
        /// Removes the cached query from cache.
        /// </summary>
        /// <typeparam name="TEntity">The type of the data in the data source.</typeparam>
        /// <param name="query">The query to be materialized.</param>
        /// <returns>
        /// The original <paramref name="query"/> for fluent chaining.
        /// </returns>
        public static IQueryable<TEntity> RemoveCache<TEntity>(this IQueryable<TEntity> query)
            where TEntity : class
        {
            IEnumerable<TEntity> removed;
            return RemoveCache(query, out removed);
        }

        /// <summary>
        /// Removes the cached query from cache.
        /// </summary>
        /// <typeparam name="TEntity">The type of the data in the data source.</typeparam>
        /// <param name="query">The query to be materialized.</param>
        /// <param name="removed">The removed items for cache.</param>
        /// <returns>
        /// The original <paramref name="query"/> for fluent chaining.
        /// </returns>
        public static IQueryable<TEntity> RemoveCache<TEntity>(this IQueryable<TEntity> query, out IEnumerable<TEntity> removed)
            where TEntity : class
        {
            string key = query.GetCacheKey();

            // allow override of CacheManager
            var manager = Locator.Current.Resolve<CacheManager>();

            removed = manager.Remove(key) as IEnumerable<TEntity>;
            return query;
        }


        /// <summary>
        /// Multiple OrderBy on materialized data
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="props"></param>
        /// <returns></returns>
        public static IEnumerable<T> OrderBy<T>(this IEnumerable<T> source, params Expression<Func<T, object>>[] props)
        {
            var enumerable = source as T[] ?? source.ToArray();
            return props.ToArray().Aggregate(enumerable, (current, prop) => current.OrderBy(prop).ToArray());
        }


        /// <summary>
        /// reverse
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="props"></param>
        /// <returns></returns>
        public static IEnumerable<T> OrderByDescending<T>(this IEnumerable<T> source, params Expression<Func<T, object>>[] props)
        {
            var enumerable = source as T[] ?? source.ToArray();
            return props.ToArray().Aggregate(enumerable, (current, prop) => current.OrderByDescending(prop).ToArray());
        }

        /// <summary>
        /// OrderBy
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="props"></param>
        /// <returns></returns>
        public static IEnumerable<T> OrderBy<T>(this IQueryable<T> source, params Expression<Func<T, object>>[] props)
        {
            var enumerable = source.AsQueryable();
            IEnumerable<T> results = enumerable.AsEnumerable();
            return props.ToArray().Aggregate(enumerable, (current, prop) => current.OrderBy(prop).AsQueryable());
        }

        public static IEnumerable<T> OrderByDescending<T>(this IQueryable<T> source, params Expression<Func<T, object>>[] props)
        {
            var enumerable = source.AsQueryable();
            IEnumerable<T> results = enumerable.AsEnumerable();
            return props.ToArray().Aggregate(enumerable, (current, prop) => current.OrderByDescending(prop).AsQueryable());
        }


        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string property)
        {
            return ApplyOrder<T>(source, property, "OrderBy");
        }
        public static IOrderedQueryable<T> OrderByDescending<T>(this IQueryable<T> source, string property)
        {
            return ApplyOrder<T>(source, property, "OrderByDescending");
        }
        public static IOrderedQueryable<T> ThenBy<T>(this IOrderedQueryable<T> source, string property)
        {
            return ApplyOrder<T>(source, property, "ThenBy");
        }
        public static IOrderedQueryable<T> ThenByDescending<T>(this IOrderedQueryable<T> source, string property)
        {
            return ApplyOrder<T>(source, property, "ThenByDescending");
        }

        /// <summary>
        /// Lambda Expressions ordering
        /// </summary>
        /// <param name="source"></param>
        /// <param name="property"></param>
        /// <param name="methodName"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IOrderedQueryable<T> ApplyOrder<T>(IQueryable<T> source, string property, string methodName)
        {
            string[] props = property.Split('.');
            Type type = typeof(T);
            ParameterExpression arg = Expression.Parameter(type, "x");
            Expression expr = arg;
            foreach (string prop in props)
            {
                // use reflection (not ComponentModel) to mirror LINQ
                PropertyInfo pi = type.GetProperty(prop);
                expr = Expression.Property(expr, pi);
                type = pi.PropertyType;
            }
            Type delegateType = typeof(Func<,>).MakeGenericType(typeof(T), type);
            LambdaExpression lambda = Expression.Lambda(delegateType, expr, arg);

            object result = typeof(Queryable).GetMethods().Single(
                    method => method.Name == methodName
                            && method.IsGenericMethodDefinition
                            && method.GetGenericArguments().Length == 2
                            && method.GetParameters().Length == 2)
                    .MakeGenericMethod(typeof(T), type)
                    .Invoke(null, new object[] { source, lambda });
            return (IOrderedQueryable<T>)result;
        }


    }
}
