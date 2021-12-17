namespace HomeAutomation.Devices;

using HomeAutomation.Devices.Domain;

public interface IDeviceRepository
{
    DeviceRegistration RetrieveDeviceRegistrationByDeviceId(string deviceId);

    void AddOrUpdateDeviceRegistration(string deviceId, string deviceName);
}