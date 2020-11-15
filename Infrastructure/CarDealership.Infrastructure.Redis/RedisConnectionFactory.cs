using CarDealership.Domain.Caching;
using StackExchange.Redis;
using System;

namespace CarDealership.Infrastructure.Redis
{
    public static class RedisConnectionFactory
    {
        private static MultiLayerCacheOptions Options;

        private static readonly Lazy<ConnectionMultiplexer> _lazyRedis = new Lazy<ConnectionMultiplexer>(() =>
            {
                var configuration = new ConfigurationOptions
                {
                    EndPoints =
                    {
                        { Options.Host, Options.Port }
                    }
                };
                return ConnectionMultiplexer.Connect(configuration);
            });

        internal static void Setup(MultiLayerCacheOptions options)
        {
            Options = options;
        }

        public static IDatabase GetConnection()
        {
            return _lazyRedis.Value.GetDatabase();
        }
    }
}
