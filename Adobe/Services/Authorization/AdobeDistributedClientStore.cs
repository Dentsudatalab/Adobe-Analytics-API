namespace Adobe.Services.Authorization
{
    using Microsoft.Extensions.Caching.Distributed;

    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;

    using Utility.Auth;

    public class AdobeDistributedClientStore : IAdobeClientStore
    {
        private readonly IDistributedCache _cache;
        private readonly string _cacheKey;
        private readonly DistributedCacheEntryOptions _options;
        private readonly object _lockObject;

        public AdobeDistributedClientStore(
            IDistributedCache cache,
            DistributedCacheEntryOptions options,
            string cacheKey)
        {
            _cache = cache;
            _cacheKey = cacheKey;
            _options = options;
            _lockObject = new object();
        }

        public virtual IdentityClient Client
        {
            get
            {
                lock (_lockObject)
                {
                    var bytes = _cache.Get(_cacheKey);

                    if (bytes == null)
                        return null;

                    var binaryFormatter = new BinaryFormatter();

                    using (var memoryStream = new MemoryStream(bytes))
                    {
                        return binaryFormatter.Deserialize(memoryStream) as IdentityClient;
                    }
                }
            }
            set
            {
                lock (_lockObject)
                {
                    if (value == null)
                        return;

                    var binaryFormatter = new BinaryFormatter();

                    using (var memoryStream = new MemoryStream())
                    {
                        binaryFormatter.Serialize(memoryStream, value);
                        var bytes = memoryStream.ToArray();

                        _cache.Set(_cacheKey, bytes, _options);
                    }
                }
            }
        }
    }
}
