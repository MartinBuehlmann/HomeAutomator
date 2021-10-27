using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeAutomator.Hue.HueItems;
using Q42.HueApi;
using Q42.HueApi.Interfaces;

namespace HomeAutomator.Hue.Services
{
    internal class HueService : IHueService
    {
        public async Task<IReadOnlyList<HueBridge>> DiscoverBridgesAsync()
        {
            IBridgeLocator locator = new HttpBridgeLocator();
            var bridges = await locator.LocateBridgesAsync(TimeSpan.FromSeconds(5));
            return bridges.Select(x => new HueBridge { Id = x.BridgeId, IpAddress = x.IpAddress }).ToList();
        }

        public async Task<HueAppKey> RegisterAppAsync(HueBridge bridge, string appName, string deviceName)
        {
            ILocalHueClient client = new LocalHueClient(bridge.IpAddress);
            var appKey = await client.RegisterAsync(appName, deviceName);
            return new HueAppKey { Key = appKey };
        }
    }
}