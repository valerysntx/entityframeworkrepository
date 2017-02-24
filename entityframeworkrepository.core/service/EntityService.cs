using System;
using System.Collections.Generic;
using entityframeworkrepository.core.entity;
using entityframeworkrepository.core.repository;
using entityframeworkrepository.core.unitofwork;

namespace entityframeworkrepository.core.service
{
    /// <summary>
    /// EntityService
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class EntityService<T> : IEntityService<T> where T : BaseEntity
    {
        readonly IUnitOfWork _unitOfWork;
        readonly IGenericDataRepository<T> _repository;

        public EntityService(IUnitOfWork unitOfWork, IGenericDataRepository<T> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _repository.Add(entity);
            _unitOfWork.Commit();
        }


        /// <summary>
        /// Update
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            _repository.Update(entity);
            _unitOfWork.Commit();
        }


        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Delete(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            _repository.Remove(entity);
            _unitOfWork.Commit();
        }


        /// <summary>
        /// GetAll
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<T> GetAll()
        {
            return _repository.GetAll();
        }
    }
}