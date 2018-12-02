using System;
using CachingSolutionsSamples.CacheServices;

namespace CachingSolutionsSamples
{
    public class Fibonacci
    {
        private readonly ICache<int> _cache;

        public Fibonacci(ICache<int> cache)
        {
            _cache = cache;
        }

        public int ComputeFibonacci(int index)
        {
            if (index <= 0)
            {
                throw new ArgumentException($"{nameof(index)} must be positive number");
            }

            if (index == 1 || index == 2)
            {
                return 1;
            }

            int fromCache = _cache.Get(index.ToString());
            if (fromCache != default(int))
            {
                Console.WriteLine($"From cache: {fromCache}");
                return fromCache;
            }

            int result = ComputeFibonacci(index - 1) + ComputeFibonacci(index - 2);
            Console.WriteLine($"Computed: {result}");
            _cache.Set(index.ToString(), result, DateTimeOffset.Now.AddMilliseconds(300));
            return result;
        }
    }
}
