namespace HomeAutomator.Settings.Domain;

public class LightSettings
{
    public LightSettings(
        string id,
        bool on,
        string color,
        int brightness)
    {
        this.Id = id;
        this.On = on;
        this.Color = color;
        this.Brightness = brightness;
    }

    public string Id { get; }

    public bool On { get; }

    /// <summary>
    ///     Gets the Color in RGB using hex values (i.e. A0EBFF).
    /// </summary>
    public string Color { get; }

    /// <summary>
    ///     Gets the Brightness in percents (0: dark, 100: bright).
    /// </summary>
    public int Brightness { get; }
}