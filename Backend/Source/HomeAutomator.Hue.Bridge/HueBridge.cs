using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeAutomator.Hue.Domain;
using Q42.HueApi;
using Q42.HueApi.Interfaces;
using Q42.HueApi.Models.Bridge;

namespace HomeAutomator.Hue.Bridge
{
    internal class HueBridge : IHueBridge
    {
        public async Task<IReadOnlyList<Domain.HueBridge>> DiscoverBridgesAsync()
        {
            IBridgeLocator locator = new HttpBridgeLocator();
            IEnumerable<LocatedBridge> bridges = await locator.LocateBridgesAsync(TimeSpan.FromSeconds(5));
            return bridges.Select(x => new Domain.HueBridge(x.BridgeId, x.IpAddress)).ToList();
        }

        public async Task<HueAppRegistration?> RegisterAppAsync(Domain.HueBridge bridge, string appName, string deviceName)
        {
            ILocalHueClient client = new LocalHueClient(bridge.IpAddress);
             string? appKey = await client.RegisterAsync(appName, deviceName);
             return string.IsNullOrEmpty(appKey) ? null : new HueAppRegistration(bridge.BridgeId, appKey);
        }
    }
}