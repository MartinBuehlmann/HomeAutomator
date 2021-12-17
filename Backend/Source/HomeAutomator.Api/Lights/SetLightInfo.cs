namespace HomeAutomator.Api.Lights;

public class SetLightInfo
{
    public SetLightInfo(
        bool isOn,
        string color,
        int brightness)
    {
        this.IsOn = isOn;
        this.Color = color;
        this.Brightness = brightness;
    }

    public bool IsOn { get; }

    /// <summary>
    ///     Color in RGB using hex values (i.e. A0EBFF)
    /// </summary>
    public string Color { get; }

    /// <summary>
    ///     Brightness in percents (0: dark, 100: bright)
    /// </summary>
    public int Brightness { get; }
}