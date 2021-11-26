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

namespace HomeAutomator.Hue.Bridge
{
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

            public void Initialize(Domain.HueBridge bridge, HueAppRegistration appRegistration)
            {
                this.client = new LocalHueClient(bridge.IpAddress);
                client.Initialize(appRegistration.AppKey);
            }

            public async Task<IReadOnlyList<HueLight>> RetrieveLightsAsync()
            {
                var nativeLights = await this.client!.GetLightsAsync();
                return nativeLights.Select(HueLightMapper.Map).ToList();
            }

            public async Task SetLightAsync(HueLight light)
            {
                var command = new LightCommand();
                command.On = light.State.On;
                command.SetColor(new RGBColor(light.State.Color));
                command.Brightness = light.State.Brightness;
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
        }
    }
}