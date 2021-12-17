namespace HomeAutomator;

using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

public static class CommonExtensions
{
    public static IServiceCollection AddCommonServices(this IServiceCollection services)
    {
        services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
        return services;
    }
}