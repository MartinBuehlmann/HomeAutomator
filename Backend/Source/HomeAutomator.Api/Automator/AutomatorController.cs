namespace HomeAutomator.Api.Automator;

using System.Collections.Generic;
using System.Threading.Tasks;
using HomeAutomator.Hue;
using HomeAutomator.Hue.Domain;
using HomeAutomator.Settings;
using HomeAutomator.Settings.Domain;
using Microsoft.AspNetCore.Mvc;

public class AutomatorController : ApiController
{
    private readonly IHueBridge hueBridge;
    private readonly ISettingsRepository settingsRepository;

    public AutomatorController(
        ISettingsRepository settingsRepository,
        IHueBridge hueBridge)
    {
        this.settingsRepository = settingsRepository;
        this.hueBridge = hueBridge;
    }

    [HttpPut]
    public async Task<IActionResult> AutomateAsync([FromBody] AutomatorInfo data)
    {
        IReadOnlyList<LightSettings> lightSettings =
            this.settingsRepository.RetrieveAssignedLightSettings(data.TagId, data.DeviceId);

        foreach (LightSettings lightSetting in lightSettings)
        {
            await this.hueBridge.SetLightAsync(
                new HueLight(
                    lightSetting.Id,
                    lightSetting.On,
                    lightSetting.Color,
                    lightSetting.Brightness));
        }

        return new OkResult();
    }
}