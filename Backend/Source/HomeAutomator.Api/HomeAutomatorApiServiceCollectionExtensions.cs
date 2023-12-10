namespace HomeAutomator.Api;

using Microsoft.Extensions.DependencyInjection;

public static class HomeAutomatorApiServiceCollectionExtensions
{
    public static IServiceCollection AddHomeAutomatorApi(this IServiceCollection services)
    {
        services.AddTransient<UrlBuilder>();
        return services;
    }
}