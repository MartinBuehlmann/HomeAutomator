using System.Threading.Tasks;
using HomeAutomation.Devices;
using HomeAutomation.Devices.Domain;
using Microsoft.AspNetCore.Mvc;

namespace HomeAutomator.Api.Devices
{
    [Route(ApiConstants.Route + "/[controller]")]
    public class DevicesController : ApiController
    {
        private readonly IDeviceRepository deviceRepository;

        public DevicesController(IDeviceRepository deviceRepository)
        {
            this.deviceRepository = deviceRepository;
        }

        [HttpHead("{deviceId}")]
        public IActionResult RetrieveAsync(string deviceId)
        {
            DeviceRegistration? deviceRegistration = this.deviceRepository.RetrieveDeviceRegistrationByDeviceId(deviceId);

            if (deviceRegistration != null)
            {
                return Ok();
            }

            return NotFound();
        }

        [HttpPut]
        public IActionResult RegisterDevice([FromBody] DeviceRegistrationInfo deviceRegistration)
        {
            this.deviceRepository.AddOrUpdateDeviceRegistration(deviceRegistration.DeviceId);
            return Ok();
        }
    }
}