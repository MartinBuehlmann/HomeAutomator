﻿using HomeAutomation.Devices.Domain;

namespace HomeAutomation.Devices
{
    public interface IDeviceRepository
    {
        DeviceRegistration RetrieveDeviceRegistrationByDeviceId(string deviceId);

        void AddOrUpdateDeviceRegistration(string deviceId, string deviceName);
    }
}