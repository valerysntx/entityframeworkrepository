using System;

// ReSharper disable CheckNamespace
namespace entityframeworkrepository.cache
{
    public interface ICachePolicy
    {
        DateTimeOffset AbsoluteExpiration { get; set; }
        TimeSpan Duration { get; set; }
        CacheExpirationMode Mode { get; set; }
        TimeSpan SlidingExpiration { get; set; }
    }
}