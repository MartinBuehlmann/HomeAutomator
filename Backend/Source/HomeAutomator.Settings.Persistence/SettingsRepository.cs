using System;
using System.Collections.Generic;
using System.Linq;
using HomeAutomator.FileStorage;
using HomeAutomator.Settings.Domain;
using HomeAutomator.Settings.Persistence.Entities;

namespace HomeAutomator.Settings.Persistence
{
    internal class SettingsRepository : ISettingsRepository
    {
        private const string Prefix = "Settings_";
        private const string LightAssignmentsName = Prefix + "LightAssignments";
        private readonly IFileStorage fileStorage;

        public SettingsRepository(IFileStorage fileStorage)
        {
            this.fileStorage = fileStorage;
        }

        public IReadOnlyList<LightSettings> RetrieveAssignedLightSettings(string tagId, string deviceId)
        {
            var deviceRegistrations = this.fileStorage.Read<LightAssignments>(LightAssignmentsName);
            return deviceRegistrations?.Items
                .SingleOrDefault(x => x.TagId == tagId && x.DeviceId == deviceId)?
                .Lights ?? Array.Empty<LightSettings>();
        }

        public void AddOrUpdateAssignedLightSettings(string tagId, string deviceId, IReadOnlyList<LightSettings> lightSettings)
        {
            this.fileStorage.Update<LightAssignments>(LightAssignmentsName, lightAssignments =>
            {
                lightAssignments.Items.RemoveAll(x => x.TagId == tagId && x.DeviceId == deviceId);
                lightAssignments.Items.Add(new LightAssignment(tagId, deviceId, lightSettings));
            });
        }

        public void UpdateAssignedLightSettings(string tagId, string deviceId, LightSettings lightSettings)
        {
            this.fileStorage.Update<LightAssignments>(LightAssignmentsName, lightAssignments =>
            {
                List<LightSettings> lights = lightAssignments.Items
                    .Single(x => x.TagId == tagId && x.DeviceId == deviceId)
                    .Lights
                    .ToList();
                lights.RemoveAll(x => x.Id == lightSettings.Id);
                lights.Add(lightSettings);
                lightAssignments.Items.RemoveAll(x => x.TagId == tagId && x.DeviceId == deviceId);
                lightAssignments.Items.Add(new LightAssignment(tagId, deviceId, lights));
            });
        }
    }
}