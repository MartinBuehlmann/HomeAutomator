using Microsoft.Extensions.DependencyInjection;

namespace HomeAutomator.Api
{
    public static class HomeAutomatorApiExtensions
    {
        public static IServiceCollection AddHomeAutomatorApi(this IServiceCollection services)
        {
            services.AddTransient<UrlBuilder>();
            return services;
        }
    }
}