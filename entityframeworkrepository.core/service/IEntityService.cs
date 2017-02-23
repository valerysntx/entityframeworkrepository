using System.Collections.Generic;
using entityframeworkrepository.core.entity;

namespace entityframeworkrepository.core.service
{
    /// <summary>
    /// IEntityService<typeparam name="T"><see cref="BaseEntity"/></typeparam>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IEntityService<T> : IService where T : BaseEntity
    {
        void Create(T entity);
        void Delete(T entity);
        IEnumerable<T> GetAll();
        void Update(T entity);
    }
}