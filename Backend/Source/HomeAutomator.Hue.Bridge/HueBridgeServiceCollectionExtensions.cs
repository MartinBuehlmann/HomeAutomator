namespace HomeAutomator.Hue.Bridge
{
    using Microsoft.Extensions.DependencyInjection;

    public static class HueBridgeServiceCollectionExtensions
    {
        public static IServiceCollection AddHueBridge(this IServiceCollection services)
        {
            services.AddScoped<IHueBridge, HueBridge>();
            services.AddTransient<HueClientFactory>();
            return services;
        }
    }
}