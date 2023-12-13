namespace HomeAutomator.Devices.Persistence;

using System;
using System.Linq;
using HomeAutomator.Devices;
using HomeAutomator.Devices.Domain;
using HomeAutomator.Devices.Persistence.Entities;
using HomeAutomator.FileStorage;

internal class DeviceRepository : IDeviceRepository
{
    private const string Prefix = "Devices_";
    private const string DeviceRegistrationsName = Prefix + "DeviceRegistration";
    private readonly IFileStorage fileStorage;

    public DeviceRepository(IFileStorage fileStorage)
    {
        this.fileStorage = fileStorage;
    }

    public DeviceRegistration? RetrieveDeviceRegistrationByDeviceId(string deviceId)
    {
        var deviceRegistrations = this.fileStorage.Read<DeviceRegistrations>(DeviceRegistrationsName);
        return deviceRegistrations?.Items.SingleOrDefault(x => x.DeviceId == deviceId);
    }

    public void AddOrUpdateDeviceRegistration(string deviceId, string deviceName)
    {
        this.fileStorage.Update<DeviceRegistrations>(DeviceRegistrationsName,
            deviceRegistrations =>
            {
                deviceRegistrations.Items.RemoveAll(x => x.DeviceId == deviceId);
                deviceRegistrations.Items.Add(new DeviceRegistration(deviceId, deviceName, DateTimeOffset.UtcNow));
            });
    }
}