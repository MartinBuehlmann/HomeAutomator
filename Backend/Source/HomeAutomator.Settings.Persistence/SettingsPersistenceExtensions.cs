using Microsoft.Extensions.DependencyInjection;

namespace HomeAutomator.Settings.Persistence
{
    public static class SettingsPersistenceExtensions
    {
        public static IServiceCollection AddSettingsPersistence(this IServiceCollection services)
        {
            services.AddScoped<ISettingsRepository, SettingsRepository>();
            return services;
        }
    }
}