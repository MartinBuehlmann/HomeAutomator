﻿namespace HomeAutomator.Devices.Persistence;

using HomeAutomator.Devices;
using Microsoft.Extensions.DependencyInjection;

public static class DevicesPersistenceServiceCollectionExtensions
{
    public static IServiceCollection AddDevicesPersistence(this IServiceCollection services)
    {
        services.AddScoped<IDeviceRepository, DeviceRepository>();
        return services;
    }
}