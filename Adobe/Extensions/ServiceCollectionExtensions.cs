namespace Adobe.Extensions
{
    using System;
    using Microsoft.Extensions.Caching.Distributed;
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.Extensions.DependencyInjection;

    using Services.Authorization;
    using Services.Endpoints;

    using Settings;

    public static class ServiceCollectionExtensions
    {
        public static void AddAdobeServices(this IServiceCollection services, AdobeSettings settings = null)
        {
            AddAuthorizationService(services, settings);

            services.AddTransient<DimensionService>();
            services.AddTransient<MetricService>();
            services.AddTransient<ReportService>();
            services.AddTransient<SegmentService>();
            services.AddTransient<UserService>();

            services.AddHttpClient<DimensionService>();
            services.AddHttpClient<MetricService>();
            services.AddHttpClient<ReportService>();
            services.AddHttpClient<SegmentService>();
            services.AddHttpClient<UserService>();
        }

        private static void AddAuthorizationService(IServiceCollection services, AdobeSettings settings = null)
        {
            if (settings == null)
                settings = new AdobeSettings();

            if (settings.ClientStore == ClientStoreType.Singleton)
            {
                services.AddSingleton<IAdobeClientStore, AdobeClientStore>();
            }
            else if (settings.ClientStore == ClientStoreType.MemoryCache)
            {
                services.AddScoped<IAdobeClientStore, AdobeMemoryClientStore>(sp =>
                {
                    var cache = sp.GetRequiredService<IMemoryCache>();

                    var cacheSettings = new MemoryCacheEntryOptions();

                    if (settings.AbsoluteExpiration.HasValue)
                        cacheSettings.SetAbsoluteExpiration(settings.AbsoluteExpiration.Value);

                    if (settings.SlidingExpiration.HasValue)
                        cacheSettings.SetSlidingExpiration(settings.SlidingExpiration.Value);

                    if (settings.Priority.HasValue)
                        cacheSettings.SetPriority(settings.Priority.Value);

                    return new AdobeMemoryClientStore(cache, cacheSettings, settings.CacheKey);
                });
            }
            else if (settings.ClientStore == ClientStoreType.DistributedCache)
            {
                services.AddScoped<IAdobeClientStore, AdobeDistributedClientStore>(sp =>
                {
                    var cache = sp.GetRequiredService<IDistributedCache>();

                    var cacheSettings = new DistributedCacheEntryOptions();

                    if (settings.AbsoluteExpiration.HasValue)
                        cacheSettings.SetAbsoluteExpiration(settings.AbsoluteExpiration.Value);

                    if (settings.SlidingExpiration.HasValue)
                        cacheSettings.SetSlidingExpiration(settings.SlidingExpiration.Value);

                    return new AdobeDistributedClientStore(cache, cacheSettings, settings.CacheKey);
                });
            }

            services.AddTransient<AdobeAuthorizationService>();
        }
    }
}