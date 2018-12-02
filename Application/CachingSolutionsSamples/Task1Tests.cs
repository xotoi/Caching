using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using CachingSolutionsSamples.CacheServices;

namespace CachingSolutionsSamples
{
    [TestClass]
    public class Task1Tests
    {
        private readonly string _fibonacciPrefix = "_fibonacci";

        [TestMethod]
        public void FibonacciMemoryCache()
        {
            var fibonacci = new Fibonacci(new MemoryCache<int>(_fibonacciPrefix));

            for (var i = 1; i < 20; i++)
            {
                Console.WriteLine(fibonacci.ComputeFibonacci(i));
                Thread.Sleep(100);
            }
        }

        [TestMethod]
        public void FibonacciRedisCache()
        {
            var fibonacci = new Fibonacci(new RedisCache<int>("localhost", _fibonacciPrefix));

            for (var i = 1; i < 20; i++)
            {
                Console.WriteLine(fibonacci.ComputeFibonacci(i));
                Thread.Sleep(100);
            }
        }
    }
}
