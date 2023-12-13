namespace HomeAutomator.Api.Devices;

using HomeAutomator.Devices;
using HomeAutomator.Devices.Domain;
using Microsoft.AspNetCore.Mvc;

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

        if (deviceRegistration is null) return this.Ok();

        return this.NotFound();
    }

    [HttpPut]
    public IActionResult RegisterDevice([FromBody] DeviceRegistrationInfo deviceRegistration)
    {
        this.deviceRepository.AddOrUpdateDeviceRegistration(deviceRegistration.DeviceId, deviceRegistration.DeviceName);
        return this.Ok();
    }
}