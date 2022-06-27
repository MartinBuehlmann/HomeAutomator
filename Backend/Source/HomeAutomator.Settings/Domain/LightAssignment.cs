namespace HomeAutomator.Settings.Domain
{
    using System.Collections.Generic;

    public record LightAssignment(
        string TagId,
        string DeviceId,
        IReadOnlyList<LightSettings> Lights);
}