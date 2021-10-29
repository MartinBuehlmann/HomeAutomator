using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HomeAutomator.Api.Configuration
{
    [Route(ApiConstants.Route + "/[controller]")]
    public class ConfigurationController : ApiController
    {
        [HttpGet("IsDeviceRegistered")]
        public async Task<IActionResult> IsDeviceRegistered(string deviceId)
        {
            return new JsonResult(await Task.FromResult(false));
        }

        [HttpPost]
        public async Task<IActionResult> RegisterDevice(string deviceId)
        {
            return new JsonResult(await Task.FromResult(true));
        }
    }
}