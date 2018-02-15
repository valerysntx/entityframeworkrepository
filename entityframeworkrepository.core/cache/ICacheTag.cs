using System;


namespace entityframeworkrepository.cache
{
    public interface ICacheTag : IEquatable<ICacheTag>
    {
        string Tag { get; }
    }
}