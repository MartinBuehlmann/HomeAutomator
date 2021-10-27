using Microsoft.Extensions.DependencyInjection;

namespace HomeAutomator.Hue.Services
{
    public static class HueServiceExtensions
    {
        public static IServiceCollection AddHueServices(this IServiceCollection services)
        {
            services.AddScoped<IHueService, HueService>();
            return services;
        }
    }
}