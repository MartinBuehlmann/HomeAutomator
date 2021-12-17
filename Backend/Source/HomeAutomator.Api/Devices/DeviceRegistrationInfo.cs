namespace HomeAutomator.Api.Devices;

public class DeviceRegistrationInfo
{
    public DeviceRegistrationInfo(string deviceId, string deviceName)
    {
        this.DeviceId = deviceId;
        this.DeviceName = deviceName;
    }

    public string DeviceId { get; }

    public string DeviceName { get; }
}