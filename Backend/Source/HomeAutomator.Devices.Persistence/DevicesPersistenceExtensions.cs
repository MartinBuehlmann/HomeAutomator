using HomeAutomation.Devices;
using Microsoft.Extensions.DependencyInjection;

namespace HomeAutomator.Devices.Persistence
{
    public static class DevicesPersistenceExtensions
    {
        public static IServiceCollection AddDevicesPersistence(this IServiceCollection services)
        {
            services.AddScoped<IDeviceRepository, DeviceRepository>();
            return services;
        }
    }
}