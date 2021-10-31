namespace HomeAutomator.Api.Devices
{
    public class DeviceRegistrationInfo
    {
        public DeviceRegistrationInfo(string deviceId)
        {
            DeviceId = deviceId;
        }

        public string DeviceId { get; }
    }
}