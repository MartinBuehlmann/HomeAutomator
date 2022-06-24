namespace HomeAutomator.Hue.Persistence
{
    using Microsoft.Extensions.DependencyInjection;

    public static class HuePersistenceServiceCollectionExtensions
    {
        public static IServiceCollection AddHuePersistence(this IServiceCollection services)
        {
            services.AddScoped<IHueRepository, HueRepository>();
            return services;
        }
    }
}