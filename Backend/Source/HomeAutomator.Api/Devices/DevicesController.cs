namespace HomeAutomator.Api.Devices;

using HomeAutomation.Devices;
using HomeAutomation.Devices.Domain;
using Microsoft.AspNetCore.Mvc;

public class DevicesController : ApiController
{
    private readonly IDeviceRepository deviceRepository;

    public DevicesController(IDeviceRepository deviceRepository)
    {
        this.deviceRepository = deviceRepository;
    }

    [HttpHead("{deviceId}")]
    public IActionResult Retrieve(string deviceId)
    {
        DeviceRegistration? deviceRegistration = this.deviceRepository.RetrieveDeviceRegistrationByDeviceId(deviceId);

        if (deviceRegistration != null)
        {
            return this.Ok();
        }

        return this.NotFound();
    }

    [HttpPut]
    public IActionResult RegisterDevice([FromBody] DeviceRegistrationInfo deviceRegistration)
    {
        this.deviceRepository.AddOrUpdateDeviceRegistration(deviceRegistration.DeviceId, deviceRegistration.DeviceName);
        return this.Ok();
    }
}