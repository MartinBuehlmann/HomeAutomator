using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeAutomator.Hue;
using HomeAutomator.Hue.Domain;
using Microsoft.AspNetCore.Mvc;

namespace HomeAutomator.Api.Lights
{
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
                await RetrieveAllLightsAsync());
        }
        
        [HttpGet("{lightId}")]
        public async Task<IActionResult> RetrieveLightAsync(string lightId)
        {
            IReadOnlyList<LightInfo> lights = await RetrieveAllLightsAsync();
            LightInfo? light = lights.SingleOrDefault(x => x.Id == lightId);

            if (light != null)
            {
                return new JsonResult(light);
            }

            return NotFound();
        }
        
        private async Task<IReadOnlyList<LightInfo>> RetrieveAllLightsAsync()
        {
            IReadOnlyList<HueLight> hueLights = await this.hueBridge.RetrieveLightsAsync();
            IReadOnlyList<HueGroup> hueGroups = await this.hueBridge.RetrieveGroupsAsync();

            return hueLights.Select(x =>
                    new LightInfo(
                        x.Id,
                        x.Name,
                        x.State.On,
                        x.State.Color,
                        (int)(100.0 * x.State.Brightness / 255.0 + 0.5),
                        x.State.IsReachable,
                        hueGroups.Single(g => g.Lights.Any(l => l.Id == x.Id)).Name,
                    new Url(this.urlBuilder.Build(ApiConstants.Route, nameof(LightsController), x.Id))))
                .ToList();
        }
    }
}