using HomeAutomator.Hue.Domain;
using Q42.HueApi;
using Q42.HueApi.ColorConverters.Original;

namespace HomeAutomator.Hue.Bridge.Mappings
{
    internal static class HueLightMapper
    {
        public static HueLight Map(Light light)
        {
            return new HueLight(light.Id, MapHueLightState(light.State), light.Type, light.Name, light.ModelId, light.ProductId);
        }

        private static HueLightState MapHueLightState(State lightState)
        {
            return new HueLightState(lightState.On, lightState.ToHex(), lightState.Brightness, lightState.IsReachable);
        }
    }
}