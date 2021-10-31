using HomeAutomation.Devices;
using Microsoft.Extensions.DependencyInjection;

namespace HomeAutomator.Devices.Persistence
{
    public static class DeviceRepositoryExtensions
    {
        public static IServiceCollection AddDeviceRepository(this IServiceCollection services)
        {
            services.AddScoped<IDeviceRepository, DeviceRepository>();
            return services;
        }
    }
}