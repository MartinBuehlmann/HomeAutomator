namespace HomeAutomator.Hue.Domain
{
    public record HueLight(
        string Id,
        bool IsOn,
        string Color,
        int Brightness,
        bool? IsReachable = null,
        string? Type = null,
        string? Name = null,
        string? ModelId = null,
        string? ProductId = null);
}