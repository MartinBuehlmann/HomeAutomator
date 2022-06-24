namespace HomeAutomator.Hue.Bridge
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using HomeAutomator.Hue.Domain;
    using Q42.HueApi;
    using Q42.HueApi.Interfaces;
    using Q42.HueApi.Models.Bridge;

    internal class HueBridge : IHueBridge
    {
        private readonly HueClientFactory hueClientFactory;
        private readonly IHueRepository hueRepository;
        private IHueClient? hueClient;

        public HueBridge(IHueRepository hueRepository, HueClientFactory hueClientFactory)
        {
            this.hueRepository = hueRepository;
            this.hueClientFactory = hueClientFactory;
        }

        public async Task<IReadOnlyList<Domain.HueBridge>> DiscoverBridgesAsync()
        {
            IBridgeLocator locator = new HttpBridgeLocator();
            IEnumerable<LocatedBridge> bridges = await locator.LocateBridgesAsync(TimeSpan.FromSeconds(5));
            return bridges.Select(x => new Domain.HueBridge(x.BridgeId, x.IpAddress)).ToList();
        }

        public async Task<HueAppRegistration?> RegisterAppAsync(
            Domain.HueBridge bridge,
            string appName,
            string deviceName)
        {
            ILocalHueClient client = new LocalHueClient(bridge.IpAddress);
            string? appKey = await client.RegisterAsync(appName, deviceName);
            return string.IsNullOrEmpty(appKey) ? null : new HueAppRegistration(bridge.BridgeId, appKey);
        }

        public async Task<IReadOnlyList<HueLight>> RetrieveLightsAsync()
        {
            await this.VerifyHueClientInitializedAsync();
            return await this.hueClient!.RetrieveLightsAsync();
        }

        public async Task SetLightAsync(HueLight light)
        {
            await this.VerifyHueClientInitializedAsync();
            await this.hueClient!.SetLightAsync(light);
        }

        public async Task<IReadOnlyList<HueGroup>> RetrieveGroupsAsync()
        {
            await this.VerifyHueClientInitializedAsync();
            return await this.hueClient!.RetrieveRoomsAsync();
        }

        private async Task VerifyHueClientInitializedAsync()
        {
            if (this.hueClient == null)
            {
                string? bridgeId = this.hueRepository.RetrieveCurrentBridgeId();
                if (string.IsNullOrEmpty(bridgeId))
                {
                    throw new InvalidOperationException("A hue bridge must first be registered!");
                }

                HueAppRegistration? appRegistration = this.hueRepository.RetrieveHueAppKeyByBridgeId(bridgeId);
                if (appRegistration == null)
                {
                    throw new InvalidOperationException("App is not registered!");
                }

                IReadOnlyList<Domain.HueBridge> bridges = await this.DiscoverBridgesAsync();
                Domain.HueBridge? bridge = bridges.SingleOrDefault(x => x.BridgeId == bridgeId);
                if (bridge == null)
                {
                    throw new InvalidOperationException("Configured bridge is not available.");
                }

                this.hueClient = this.hueClientFactory.Create(bridge, appRegistration);
            }
        }
    }
}