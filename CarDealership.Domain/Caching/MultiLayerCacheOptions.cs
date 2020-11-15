namespace CarDealership.Domain.Caching
{
    public class MultiLayerCacheOptions
    {
        public string Host { get; }
        public int Port { get; }

        public MultiLayerCacheOptions(string host, int port)
        {
            Host = host;
            Port = port;
        }
    }
}
