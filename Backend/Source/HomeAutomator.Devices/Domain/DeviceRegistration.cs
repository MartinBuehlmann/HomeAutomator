namespace HomeAutomator.Devices.Domain;

using System;

public class DeviceRegistration
{
    public DeviceRegistration(
        string deviceId,
        string deviceName,
        DateTimeOffset registrationDateTime)
    {
        this.DeviceId = deviceId;
        this.DeviceName = deviceName;
        this.RegistrationDateTime = registrationDateTime;
    }

    public string DeviceId { get; }

    public string DeviceName { get; }

    public DateTimeOffset RegistrationDateTime { get; }
}