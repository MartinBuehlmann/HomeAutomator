using System.Collections.Generic;
using HomeAutomator.Settings.Domain;

namespace HomeAutomator.Settings.Persistence.Entities
{
    internal class LightAssignments
    {
        public LightAssignments()
        {
            Items = new List<LightAssignment>();
        }

        public List<LightAssignment> Items { get; }
    }
}