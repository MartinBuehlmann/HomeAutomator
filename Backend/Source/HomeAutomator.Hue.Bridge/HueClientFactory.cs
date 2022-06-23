namespace HomeAutomator.Hue.Bridge;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeAutomator.Hue.Bridge.Mappings;
using HomeAutomator.Hue.Domain;
using Q42.HueApi;
using Q42.HueApi.ColorConverters;
using Q42.HueApi.ColorConverters.Original;
using Q42.HueApi.Interfaces;
using Q42.HueApi.Models.Groups;

internal class HueClientFactory
{
    public IHueClient Create(Domain.HueBridge bridge, HueAppRegistration appRegistration)
    {
        var hueClient = new HueClient();
        hueClient.Initialize(bridge, appRegistration);
        return hueClient;
    }

    private class HueClient : IHueClient
    {
        private ILocalHueClient? client;

        public async Task<IReadOnlyList<HueLight>> RetrieveLightsAsync()
        {
            IEnumerable<Light> nativeLights = await this.client!.GetLightsAsync();
            return nativeLights.Select(HueLightMapper.Map).ToList();
        }

        public async Task SetLightAsync(HueLight light)
        {
            var command = new LightCommand();
            command.On = light.IsOn;
            command.SetColor(new RGBColor(light.Color));
            command.Brightness = (byte)(255.0 * light.Brightness / 100.0);
            await this.client!.SendCommandAsync(command, new List<string> { light.Id });
        }

        public async Task<IReadOnlyList<HueGroup>> RetrieveRoomsAsync()
        {
            IReadOnlyCollection<Group> groups = await this.client!.GetGroupsAsync();
            IReadOnlyList<HueLight> lights = await this.RetrieveLightsAsync();
            return groups
                .Where(x => x.Type == GroupType.Room)
                .Select(group => new HueGroup(
                    group.Id,
                    group.Name,
                    group.Lights.Select(light => lights.Single(x => x.Id == light)).ToList()))
                .ToList();
        }

        public void Initialize(Domain.HueBridge bridge, HueAppRegistration appRegistration)
        {
            this.client = new LocalHueClient(bridge.IpAddress);
            this.client.Initialize(appRegistration.AppKey);
        }
    }
}