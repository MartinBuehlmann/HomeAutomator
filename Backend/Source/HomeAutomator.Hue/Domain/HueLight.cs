namespace HomeAutomator.Hue.Domain;

public class HueLight
{
    public HueLight(
        string id,
        bool isOn,
        string color,
        int brightness,
        bool? isReachable = null,
        string? type = null,
        string? name = null,
        string? modelId = null,
        string? productId = null)
    {
        this.Id = id;
        this.IsOn = isOn;
        this.Color = color;
        this.Brightness = brightness;
        this.IsReachable = isReachable;
        this.Type = type;
        this.Name = name;
        this.ModelId = modelId;
        this.ProductId = productId;
    }

    public string Id { get; }

    public bool IsOn { get; set; }

    public string Color { get; set; }

    public int Brightness { get; set; }

    public bool? IsReachable { get; set; }

    public string? Type { get; }

    public string? Name { get; }

    public string? ModelId { get; }

    public string? ProductId { get; }
}