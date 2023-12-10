namespace HomeAutomator;

using HomeAutomator.Api;
using HomeAutomator.Devices.Persistence;
using HomeAutomator.FileStorage;
using HomeAutomator.Hue.Bridge;
using HomeAutomator.Hue.Persistence;
using HomeAutomator.NfcTags.Persistence;
using HomeAutomator.Settings.Persistence;
using Microsoft.Extensions.DependencyInjection;

internal static class HomeAutomatorServiceCollectionExtensions
{
    public static IServiceCollection AddHomeAutomator(this IServiceCollection services)
    {
        services.AddFileStorage();
        services.AddHueBridge();
        services.AddHuePersistence();
        services.AddDevicesPersistence();
        services.AddNfcTagsPersistence();
        services.AddHomeAutomatorApi();
        services.AddSettingsPersistence();
        return services;
    }
}