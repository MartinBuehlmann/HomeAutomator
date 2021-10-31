using System;

namespace HomeAutomation.Devices.Domain
{
    public class DeviceRegistration
    {
        public DeviceRegistration(
            string deviceId,
            DateTimeOffset registrationDateTime)
        {
            DeviceId = deviceId;
            RegistrationDateTime = registrationDateTime;
        }

        public string DeviceId { get; }

        public DateTimeOffset RegistrationDateTime { get; }
    }
}