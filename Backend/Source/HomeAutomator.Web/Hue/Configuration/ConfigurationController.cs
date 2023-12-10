namespace HomeAutomator.Web.Hue.Configuration;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeAutomator.Hue;
using HomeAutomator.Hue.Domain;
using HomeAutomator.Web.Shared.Configuration;
using Microsoft.AspNetCore.Mvc;

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
        return new JsonResult(new ConfigurationEditModel(
            registeredBridgeId ?? string.Empty,
            new[] { new HueBridgeModel(string.Empty, "--- None ---") }
                .Concat(
                    bridges.Select(x =>
                        new HueBridgeModel(x.BridgeId, $"{x.BridgeId} ({x.IpAddress})")))
                .ToArray()));
    }

    [HttpPost]
    public async Task<IActionResult> UseBridge([FromBody] ConfigurationSaveModel model)
    {
        HueAppRegistration? hueAppKey = this.hueRepository.RetrieveHueAppKeyByBridgeId(model.BridgeId);
        if (hueAppKey == null)
        {
            HueBridge bridge = (await this.hueBridge.DiscoverBridgesAsync()).Single(x => x.BridgeId == model.BridgeId);
            hueAppKey = await this.hueBridge.RegisterAppAsync(bridge, "HomeAutomator", Environment.MachineName);

            if (hueAppKey != null) this.hueRepository.AddOrUpdateHueAppRegistration(hueAppKey);
        }

        if (hueAppKey != null)
        {
            this.hueRepository.SaveOrUpdateCurrentBridgeId(model.BridgeId);
            return new OkResult();
        }

        return new UnauthorizedResult();
    }
}