namespace HomeAutomator.Hue.Persistence.Entities;

using System.Collections.Generic;
using HomeAutomator.Hue.Domain;

internal class HueAppRegistrations
{
    public HueAppRegistrations()
    {
        this.Items = new List<HueAppRegistration>();
    }

    public List<HueAppRegistration> Items { get; }
}