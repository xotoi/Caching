using System;
using System.Runtime.Caching;

namespace CachingSolutionsSamples.CacheServices
{
    public class MemoryCache<T> : ICache<T>
    {
        private readonly ObjectCache _cache = MemoryCache.Default;
        private readonly string _prefix;

        public MemoryCache(string prefix)
        {
            _prefix = prefix;
        }

        public T Get(string key)
        {
            var fromCache = _cache.Get(_prefix + key);
            if (fromCache == null)
            {
                return default(T);
            }

            return (T)fromCache;
        }

        public void Set(string key, T value, DateTimeOffset expirationDate)
        {
            _cache.Set(_prefix + key, value, expirationDate);
        }

        public void Set(string key, T value, CacheItemPolicy policy)
        {
            _cache.Set(_prefix + key, value, policy);
        }
    }
}
