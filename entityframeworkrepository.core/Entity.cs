namespace entityframeworkrepository.core
{
    public abstract class Entity<T> : BaseEntity, IEntity
    {
        public virtual T Id { get; set; }
    }
}