namespace HomeAutomator.Settings
{
    using System.Collections.Generic;
    using HomeAutomator.Settings.Domain;

    public interface ISettingsRepository
    {
        IReadOnlyList<LightSettings> RetrieveAssignedLightSettings(string tagId, string deviceId);

        void AddOrUpdateAssignedLightSettings(string tagId, string deviceId, IReadOnlyList<LightSettings> lightSettings);

        void UpdateAssignedLightSettings(string tagId, string deviceId, LightSettings lightSettings);
    }
}