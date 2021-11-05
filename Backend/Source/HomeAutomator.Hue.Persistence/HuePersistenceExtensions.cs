using Microsoft.Extensions.DependencyInjection;

namespace HomeAutomator.Hue.Persistence
{
    public static class HuePersistenceExtensions
    {
        public static IServiceCollection AddHuePersistence(this IServiceCollection services)
        {
            services.AddScoped<IHueRepository, HueRepository>();
            return services;
        }
    }
}