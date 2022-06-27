namespace HomeAutomator.Settings.Domain
{
    /// <summary>
    /// State of a specific light source.
    /// </summary>
    /// <param name="Id">Unique id of the light.</param>
    /// <param name="On">True if the light is on, otherwise false.</param>
    /// <param name="Color">The Color in RGB using hex values (i.e. A0EBFF).</param>
    /// <param name="Brightness">The Brightness in percents (0: dark, 100: bright).</param>
    public record LightSettings(
        string Id,
        bool On,
        string Color,
        int Brightness);
}