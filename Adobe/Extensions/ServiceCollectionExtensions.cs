namespace Adobe.Extensions
{
    using Microsoft.Extensions.DependencyInjection;
    using Services.Authorization;
    using Services.Endpoints;

    public static class ServiceCollectionExtensions
    {
        public static void AddAdobeServices(this IServiceCollection services)
        {
            services.AddSingleton<AdobeClientStore>();

            services.AddTransient<AdobeAuthorizationService>();

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
    }
}