namespace HomeAutomator.Settings.Persistence;

using Microsoft.Extensions.DependencyInjection;

public static class SettingsPersistenceServiceCollectionExtensions
{
    public static IServiceCollection AddSettingsPersistence(this IServiceCollection services)
    {
        services.AddScoped<ISettingsRepository, SettingsRepository>();
        return services;
    }
}