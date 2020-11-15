using CarDealership.Domain.Caching;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace CarDealership.Infrastructure.Redis
{
    public class MultiLayerCache : IMultiLayerCache 
    {
        private readonly IMemoryCache _memoryCache;
        private bool disposedValue;

        public MultiLayerCache(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public T Get<T>(string key) where T : class
        {
            if (_memoryCache.TryGetValue<string>(key, out var value))
            {
                return JsonConvert.DeserializeObject<T>(value);
            }

            var distributedCache = RedisConnectionFactory.GetConnection();
            var remote = distributedCache.StringGet(key);

            if (remote.HasValue)
            {
                _memoryCache.Set(key, remote);

                return JsonConvert.DeserializeObject<T>(remote);
            }

            return default;
        }

        public async Task<T> GetAsync<T>(string key) where T : class
        {
            if (_memoryCache.TryGetValue<string>(key, out var value))
            {
                return JsonConvert.DeserializeObject<T>(value);
            }

            var distributedCache = RedisConnectionFactory.GetConnection();
            var remote = await distributedCache.StringGetAsync(key);

            if (remote.HasValue)
            {
                _memoryCache.Set(key, remote);

                return JsonConvert.DeserializeObject<T>(remote);
            }

            return default;
        }

        public T GetOrAdd<T>(string key, Func<T> lookup) where T : class
        {
            if (_memoryCache.TryGetValue<string>(key, out var value))
            {
                return JsonConvert.DeserializeObject<T>(value);
            }

            var distributedCache = RedisConnectionFactory.GetConnection();
            var remote = distributedCache.StringGet(key);

            if (remote.HasValue)
            {
                _memoryCache.Set(key, remote);

                return JsonConvert.DeserializeObject<T>(remote);
            }

            var createdValue = lookup();
            var serializedValue = JsonConvert.SerializeObject(createdValue);

            _memoryCache.Set(key, serializedValue);
            distributedCache.StringSet(key, serializedValue);

            return createdValue;
        }

        public async Task<T> GetOrAddAsync<T>(string key, Func<T> lookup) where T : class
        {
            if (_memoryCache.TryGetValue<string>(key, out var value))
            {
                return JsonConvert.DeserializeObject<T>(value);
            }

            var distributedCache = RedisConnectionFactory.GetConnection();
            var remote = await distributedCache.StringGetAsync(key);

            if (remote.HasValue)
            {
                _memoryCache.Set(key, remote);

                return JsonConvert.DeserializeObject<T>(remote);
            }

            var createdValue = lookup();
            var serializedValue = JsonConvert.SerializeObject(createdValue);

            _memoryCache.Set(key, serializedValue);
            await distributedCache.StringSetAsync(key, serializedValue);

            return createdValue;
        }

        public void Set<T>(string key, T value) where T : class
        {
            var serializedValue = JsonConvert.SerializeObject(value);
            
            _memoryCache.Set(key, serializedValue);

            var distributedCache = RedisConnectionFactory.GetConnection();
            distributedCache.StringSet(key, serializedValue);
        }

        public async void SetAsync<T>(string key, T value) where T : class
        {
            var serializedValue = JsonConvert.SerializeObject(value);

            _memoryCache.Set(key, serializedValue);

            var distributedCache = RedisConnectionFactory.GetConnection();
            await distributedCache.StringSetAsync(key, serializedValue);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _memoryCache.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
