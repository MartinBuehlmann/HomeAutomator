namespace HomeAutomator.Devices
{
    using HomeAutomator.Devices.Domain;

    public interface IDeviceRepository
    {
        DeviceRegistration? RetrieveDeviceRegistrationByDeviceId(string deviceId);

        void AddOrUpdateDeviceRegistration(string deviceId, string deviceName);
    }
}