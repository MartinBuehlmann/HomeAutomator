using System.Collections.Generic;
using HomeAutomation.Devices.Domain;

namespace HomeAutomator.Devices.Persistence.Entities
{
    public class DeviceRegistrations
    {
        public DeviceRegistrations()
        {
            Items = new List<DeviceRegistration>();
        }

        public List<DeviceRegistration> Items { get; }
    }
}