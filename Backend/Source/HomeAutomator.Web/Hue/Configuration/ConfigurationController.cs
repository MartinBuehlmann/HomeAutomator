using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeAutomator.Hue;
using HomeAutomator.Hue.Domain;
using HomeAutomator.Web.Shared.Hue.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace HomeAutomator.Web.Hue.Configuration
{
    [Route(WebConstants.Route + "/" + HueConstants.UrlPath + "/[controller]")]
    public class ConfigurationController : WebController
    {
        private readonly IHueBridge hueBridge;
        private readonly IHueRepository hueRepository;

        public ConfigurationController(
            IHueBridge hueBridge,
            IHueRepository hueRepository)
        {
            this.hueBridge = hueBridge;
            this.hueRepository = hueRepository;
        }

        [HttpGet]
        public async Task<IActionResult> RetrieveBridges()
        {
            IReadOnlyList<HueBridge> bridges = await this.hueBridge.DiscoverBridgesAsync();
            string? registeredBridgeId = this.hueRepository.RetrieveCurrentBridgeId();
            return new JsonResult(new HueBridgeConfigurationModel
            {
                Id = registeredBridgeId,
                DiscoveredHueBridges = new[] {new HueBridgeModel(null, "--- None ---")}
                    .Concat(
                        bridges.Select(x =>
                            new HueBridgeModel(x.BridgeId, $"{x.BridgeId} ({x.IpAddress})")))
                    .ToArray()
            });
        }

        [HttpPost("id")]
        public async Task<IActionResult> UseBridge(string id)
        {
            HueAppRegistration? hueAppKey = this.hueRepository.RetrieveHueAppKeyByBridgeId(id);
            if (hueAppKey == null)
            {
                HueBridge bridge = (await this.hueBridge.DiscoverBridgesAsync()).Single(x => x.BridgeId == id);
                hueAppKey = await this.hueBridge.RegisterAppAsync(bridge, "HomeAutomator",
                    "Device"); // TODO: Discover unique device name

                if (hueAppKey != null)
                {
                    this.hueRepository.AddOrUpdateHueAppRegistration(hueAppKey);
                }
            }

            if (hueAppKey != null)
            {
                this.hueRepository.SaveOrUpdateCurrentBridgeId(id);
                return new OkResult();
            }

            return new UnauthorizedResult();
        }
    }
}