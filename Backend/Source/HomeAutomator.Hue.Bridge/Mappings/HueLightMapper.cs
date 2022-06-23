namespace HomeAutomator.Hue.Bridge.Mappings;

using HomeAutomator.Hue.Domain;
using Q42.HueApi;
using Q42.HueApi.ColorConverters.Original;

internal static class HueLightMapper
{
    public static HueLight Map(Light light)
    {
        return new HueLight(
            light.Id,
            light.State.On,
            light.State.ToHex(),
            (int)((100.0 * light.State.Brightness / 255.0) + 0.5),
            light.State.IsReachable,
            light.Type,
            light.Name,
            light.ModelId,
            light.ProductId);
    }
}