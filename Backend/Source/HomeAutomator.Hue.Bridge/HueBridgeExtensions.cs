using Microsoft.Extensions.DependencyInjection;

namespace HomeAutomator.Hue.Bridge
{
    public static class HueBridgeExtensions
    {
        public static IServiceCollection AddHueBridge(this IServiceCollection services)
        {
            services.AddScoped<IHueBridge, HueBridge>();
            services.AddTransient<HueClientFactory>();
            return services;
        }
    }
}