namespace HomeAutomator.Hue.Domain
{
    using System.Collections.Generic;

    public record HueGroup(
        string Id,
        string Name,
        IReadOnlyList<HueLight> Lights);
}