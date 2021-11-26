using System.Collections.Generic;
using HomeAutomator.Hue.Domain;

namespace HomeAutomator.Hue.Persistence.Entities
{
    internal class HueAppRegistrations
    {
        public HueAppRegistrations()
        {
            this.Items = new List<HueAppRegistration>();
        }

        public List<HueAppRegistration> Items { get; }
    }
}