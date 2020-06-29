namespace Adobe.Settings
{
    using System;

    using Microsoft.Extensions.Caching.Memory;

    public class AdobeSettings
    {
        public ClientStoreType ClientStore { get; set; } = ClientStoreType.Singleton;

        public TimeSpan? AbsoluteExpiration { get; set; }

        public TimeSpan? SlidingExpiration { get; set; }

        public CacheItemPriority? Priority { get; set; }

        public string CacheKey { get; set; } = "ADOBE_CLIENT_STORE_IDENTITY_CLIENT";
    }
}
