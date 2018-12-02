using System;

namespace CachingSolutionsSamples.CacheServices
{
    public interface ICache<T>
    {
        T Get(string key);
        void Set(string key, T value, DateTimeOffset expirationDate);
    }
}
