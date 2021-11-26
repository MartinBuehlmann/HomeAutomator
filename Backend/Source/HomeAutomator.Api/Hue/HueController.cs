using System.Collections.Generic;
using System.Threading.Tasks;
using HomeAutomator.Hue;
using HomeAutomator.Hue.Domain;
using Microsoft.AspNetCore.Mvc;

namespace HomeAutomator.Api.Hue
{
    // TODO: Obsolete
    public class HueController : ApiController
    {
        private readonly IHueBridge hueBridge;

        public HueController(IHueBridge hueBridge)
        {
            this.hueBridge = hueBridge;
        }

        [HttpGet("lights")]
        public async Task<IActionResult> RetrieveLights()
        {
            IReadOnlyList<HueLight> hueLights =  await this.hueBridge.RetrieveLightsAsync();
            return new JsonResult(hueLights);
        }

        [HttpPut("lights")]
        public async Task<IActionResult> SetLight([FromBody] HueLight light)
        {
            await hueBridge.SetLightAsync(light);
            return new OkResult();
        }
    }
}