using System;
using System.Linq;
using HomeAutomation.Devices;
using HomeAutomation.Devices.Domain;
using HomeAutomator.Devices.Persistence.Entities;
using HomeAutomator.FileStorage;

namespace HomeAutomator.Devices.Persistence
{
    public class DeviceRepository : IDeviceRepository
    {
        private const string Prefix = "Devices_";
        private const string DeviceRegistrationsName = Prefix + "DeviceRegistration";
        private readonly IFileStorage fileStorage;

        public DeviceRepository(IFileStorage fileStorage)
        {
            this.fileStorage = fileStorage;
        }

        public DeviceRegistration RetrieveDeviceRegistrationByDeviceId(string deviceId)
        {
            var deviceRegistrations = this.fileStorage.Read<DeviceRegistrations>(DeviceRegistrationsName);
            return deviceRegistrations?.Items.SingleOrDefault(x => x.DeviceId == deviceId);
        }

        // TODO: Make thread safe
        public void AddOrUpdateDeviceRegistration(string deviceId, string deviceName)
        {
            var deviceRegistrations = this.fileStorage.Read<DeviceRegistrations>(DeviceRegistrationsName) ??
                                      new DeviceRegistrations();
            deviceRegistrations.Items.RemoveAll(x => x.DeviceId == deviceId);
            deviceRegistrations.Items.Add(new DeviceRegistration(deviceId, deviceName, DateTimeOffset.UtcNow));
            this.fileStorage.Write(deviceRegistrations, DeviceRegistrationsName);
        }
    }
}