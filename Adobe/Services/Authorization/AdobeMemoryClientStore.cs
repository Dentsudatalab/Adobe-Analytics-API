namespace Adobe.Services.Authorization
{
    using Microsoft.Extensions.Caching.Memory;

    using Utility.Auth;

    public class AdobeMemoryClientStore : IAdobeClientStore
    {
        private readonly IMemoryCache _cache;
        private readonly string _cacheKey;
        private readonly MemoryCacheEntryOptions _options;
        private readonly object _lockObject;

        public AdobeMemoryClientStore(IMemoryCache cache, MemoryCacheEntryOptions options, string cacheKey)
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
                    return _cache.Get<IdentityClient>(_cacheKey);
                }
            }
            set
            {
                lock (_lockObject)
                {
                    _cache.Set(_cacheKey, value, _options);
                }
            }
        }
    }
}
