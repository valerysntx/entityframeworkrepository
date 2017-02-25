using System;
// ReSharper disable CheckNamespace

namespace entityframeworkrepository.cache
{
    public interface ICacheTag : IEquatable<ICacheTag>
    {
        string Tag { get; }
    }
}