using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading;
using NorthwindLibrary;
using System.Collections.Generic;
using CachingSolutionsSamples.CacheServices;

namespace CachingSolutionsSamples
{
    [TestClass]
    public class Task2Tests
    {
        private readonly string _categoriesPrefix = "Cache_Categories";
        private readonly string _customersPrefix = "Cache_Customers";
        private readonly string _suppliersPrefix = "Cache_Suppliers";

        [TestMethod]
        public void CategoriesMemoryCache()
        {
            var entitiesManager = new EntitiesManager<Category>(new MemoryCache<IEnumerable<Category>>(_categoriesPrefix));

            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine(entitiesManager.GetEntities().Count());
                Thread.Sleep(100);
            }
        }

        [TestMethod]
        public void CategoriesRedisCache()
        {
            var entitiesManager = new EntitiesManager<Category>(new RedisCache<IEnumerable<Category>>("localhost", _categoriesPrefix));

            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine(entitiesManager.GetEntities().Count());
                Thread.Sleep(100);
            }
        }

        [TestMethod]
        public void CustomersMemoryCache()
        {
            var entitiesManager = new EntitiesManager<Customer>(new MemoryCache<IEnumerable<Customer>>(_customersPrefix));

            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine(entitiesManager.GetEntities().Count());
                Thread.Sleep(100);
            }
        }

        [TestMethod]
        public void CustomersRedisCache()
        {
            var entitiesManager = new EntitiesManager<Customer>(new RedisCache<IEnumerable<Customer>>("localhost", _customersPrefix));

            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine(entitiesManager.GetEntities().Count());
                Thread.Sleep(100);
            }
        }

        [TestMethod]
        public void SuppliersMemoryCache()
        {
            var entitiesManager = new EntitiesManager<Supplier>(new MemoryCache<IEnumerable<Supplier>>(_suppliersPrefix));

            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine(entitiesManager.GetEntities().Count());
                Thread.Sleep(100);
            }
        }

        [TestMethod]
        public void SuppliersRedisCache()
        {
            var entitiesManager = new EntitiesManager<Supplier>(new RedisCache<IEnumerable<Supplier>>("localhost", _suppliersPrefix));

            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine(entitiesManager.GetEntities().Count());
                Thread.Sleep(100);
            }
        }

        [TestMethod]
        public void SqlMonitorsTest()
        {
            var entitiesManager = new MemoryEntitiesManager<Supplier>(new MemoryCache<IEnumerable<Supplier>>(_suppliersPrefix),
                "select [SupplierID],[CompanyName],[ContactName],[ContactTitle],[Address],[City],[Region],[PostalCode],[Country],[Phone],[Fax] from [dbo].[Suppliers]");
            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine(entitiesManager.GetEntities().Count());
                Thread.Sleep(1000);
            }
        }
    }
}
