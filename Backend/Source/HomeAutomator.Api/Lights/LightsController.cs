namespace HomeAutomator.Api.Lights;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeAutomator.Hue;
using HomeAutomator.Hue.Domain;
using Microsoft.AspNetCore.Mvc;

public class LightsController : ApiController
{
    private readonly IHueBridge hueBridge;
    private readonly UrlBuilder urlBuilder;

    public LightsController(
        IHueBridge hueBridge,
        UrlBuilder urlBuilder)
    {
        this.hueBridge = hueBridge;
        this.urlBuilder = urlBuilder;
    }

    [HttpGet]
    public async Task<IActionResult> RetrieveLightsAsync()
    {
        return new JsonResult(
            await this.RetrieveAllLightsAsync());
    }

    [HttpGet("{lightId}")]
    public async Task<IActionResult> RetrieveLightAsync(string lightId)
    {
        IReadOnlyList<LightInfo> lights = await this.RetrieveAllLightsAsync();
        LightInfo? light = lights.SingleOrDefault(x => x.Id == lightId);

        if (light != null) return new JsonResult(light);

        return this.NotFound();
    }

    [HttpPut("{lightId}")]
    public async Task<IActionResult> SetLight(string lightId, [FromBody] SetLightInfo light)
    {
        await this.hueBridge.SetLightAsync(
            new HueLight(
                lightId,
                light.IsOn,
                light.Color,
                light.Brightness));
        return new OkResult();
    }

    private async Task<IReadOnlyList<LightInfo>> RetrieveAllLightsAsync()
    {
        IReadOnlyList<HueLight> hueLights = await this.hueBridge.RetrieveLightsAsync();
        IReadOnlyList<HueGroup> hueGroups = await this.hueBridge.RetrieveGroupsAsync();

        return hueLights.Select(x =>
                new LightInfo(
                    x.Id,
                    x.Name!,
                    x.IsOn,
                    x.Color,
                    x.Brightness,
                    x.IsReachable!.Value,
                    hueGroups.Single(g => g.Lights.Any(l => l.Id == x.Id)).Name,
                    new Url(this.urlBuilder.Build(ApiConstants.Route, nameof(LightsController), x.Id))))
            .ToList();
    }
}