using System.Threading.Tasks;
using HomeAutomator.Hue;
using Microsoft.AspNetCore.Mvc;

namespace HomeAutomator.Api.Hue.Configuration
{
    [Route(ApiConstants.Route + "/" + HueConstants.UrlPath + "/[controller]")]
    public class ConfigurationController : ApiController
    {
        private readonly IHueService hueService;

        public ConfigurationController(IHueService hueService)
        {
            this.hueService = hueService;
        }
        
        [HttpGet]
        public async Task<IActionResult> RetrieveBridges()
        {
            return new JsonResult(await this.hueService.DiscoverBridgesAsync());
        }
    }
}