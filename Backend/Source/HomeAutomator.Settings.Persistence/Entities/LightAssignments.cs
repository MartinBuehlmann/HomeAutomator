namespace HomeAutomator.Settings.Persistence.Entities;

using System.Collections.Generic;
using HomeAutomator.Settings.Domain;

internal class LightAssignments
{
    public LightAssignments()
    {
        this.Items = new List<LightAssignment>();
    }

    public List<LightAssignment> Items { get; }
}