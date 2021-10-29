using Microsoft.Extensions.DependencyInjection;

namespace HomeAutomator.Hue.Persistence
{
    public static class HueRepositoryExtensions
    {
        public static IServiceCollection AddHueRepository(this IServiceCollection services)
        {
            services.AddScoped<IHueRepository, HueRepository>();
            return services;
        }
    }
}