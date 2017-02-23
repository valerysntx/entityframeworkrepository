namespace entityframeworkrepository.core.entity
{
    public abstract class Entity<T> : BaseEntity, IEntity
    {
        public virtual T Id { get; set; }
    }
}