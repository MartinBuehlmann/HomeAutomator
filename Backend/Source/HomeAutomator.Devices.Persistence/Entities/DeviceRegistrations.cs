namespace HomeAutomator.Devices.Persistence.Entities;

using System.Collections.Generic;
using HomeAutomation.Devices.Domain;

internal class DeviceRegistrations
{
    public DeviceRegistrations()
    {
        this.Items = new List<DeviceRegistration>();
    }

    public List<DeviceRegistration> Items { get; }
}