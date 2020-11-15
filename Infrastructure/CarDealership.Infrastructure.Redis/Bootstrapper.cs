using CarDealership.Domain.Caching;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;
using System;

namespace CarDealership.Infrastructure.Redis
{
    public static class Bootstrapper
    {
        public static void AddMultiLayerCache(this IServiceCollection services, Container container, Func<MultiLayerCacheOptions> options)
        {
            RedisConnectionFactory.Setup(options());
            container.RegisterSingleton<IMultiLayerCache, MultiLayerCache>();
        }
    }
}
