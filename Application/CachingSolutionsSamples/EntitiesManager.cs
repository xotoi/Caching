using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using CachingSolutionsSamples.CacheServices;
using NorthwindLibrary;

namespace CachingSolutionsSamples
{
    public class EntitiesManager<T> where T : class
    {
        private readonly ICache<IEnumerable<T>> _cache;

        public EntitiesManager(ICache<IEnumerable<T>> cache)
        {
            _cache = cache;
        }

        public IEnumerable<T> GetEntities()
        {
            Console.WriteLine("Get Entities");
            var user = Thread.CurrentPrincipal.Identity.Name;
            var entities = _cache.Get(user);

            if (entities != null) return entities;

            Console.WriteLine("From no cache storage");
            using (var dbContext = new Northwind())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                dbContext.Configuration.ProxyCreationEnabled = false;
                entities = dbContext.Set<T>().ToList();
            }

            _cache.Set(user, entities, DateTimeOffset.Now.AddDays(1));

            return entities;
        }
    }
}
