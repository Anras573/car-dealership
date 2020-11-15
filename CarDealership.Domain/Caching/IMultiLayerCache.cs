using System;
using System.Threading.Tasks;

namespace CarDealership.Domain.Caching
{
    public interface IMultiLayerCache
    {
        T Get<T>(string key) where T : class;
        Task<T> GetAsync<T>(string key) where T : class;

        T GetOrAdd<T>(string key, Func<T> lookup) where T : class;
        Task<T> GetOrAddAsync<T>(string key, Func<T> lookup) where T : class;

        void Set<T>(string key, T value) where T : class;
        void SetAsync<T>(string key, T value) where T : class;
    }
}
