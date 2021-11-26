using HomeAutomator.Settings.Domain;

namespace HomeAutomator.Api.Settings
{
    using System.Collections.Generic;
    using System.Linq;
    using HomeAutomator.Api.Lights;
    using HomeAutomator.Settings;
    using Microsoft.AspNetCore.Mvc;

    public class SettingsController : ApiController
    {
        private readonly ISettingsRepository settingsRepository;
        private readonly UrlBuilder urlBuilder;

        public SettingsController(
            ISettingsRepository settingsRepository,
            UrlBuilder urlBuilder)
        {
            this.settingsRepository = settingsRepository;
            this.urlBuilder = urlBuilder;
        }

        /// <summary>
        /// Returns a list of URLs to the lights associated with the combination of NFC tag and device.
        /// </summary>
        /// <param name="tagId">Id of the NFC tag</param>
        /// <param name="deviceId">Id of the device which scanned the NFC tag</param>
        /// <returns>List of light settings assigned to the tag and device</returns>
        [HttpGet("{tagId}/{deviceId}")]
        public IActionResult RetrieveLightsByTagIdAndDeviceId(string tagId, string deviceId)
        {
            IReadOnlyList<LightSettings> lightSettings =
                this.settingsRepository.RetrieveAssignedLightSettings(tagId, deviceId);
            return new JsonResult(lightSettings.Select(x => new LightSettingsInfo(
                x.Id,
                x.On,
                x.Color,
                x.Brightness,
                new Url(this.urlBuilder.Build(ApiConstants.Route, nameof(LightsController), x.Id)))));
        }

        /// <summary>
        /// Assigns a list of lights to the combination of NFC tag and device and persists this.
        /// </summary>
        /// <param name="tagId">Id of the NFC tag</param>
        /// <param name="deviceId">Id of the device which scanned the NFC tag</param>
        /// <param name="lightSettingInfos">List of light settings to save</param>
        /// <returns></returns>
        [HttpPut("{tagId}/{deviceId}")]
        public IActionResult AddOrUpdateLightsByTagIdAndDeviceId(string tagId, string deviceId,
            [FromBody] IReadOnlyList<LightSettingsInfo> lightSettingInfos)
        {
            IReadOnlyList<LightSettings> lightSettings = lightSettingInfos
                .Select(x => new LightSettings(x.Id, x.On, x.Color, x.Brightness))
                .ToList();

            this.settingsRepository.AddOrUpdateAssignedLightSettings(tagId, deviceId, lightSettings);
            return Ok();
        }

        [HttpPut("{tagId}/{deviceId}/{lightId}")]
        public IActionResult UpdateSingleLightSettings(string tagId, string deviceId,
            [FromBody] LightSettingsInfo lightSettingInfos)
        {
            var lightSettings = new LightSettings(lightSettingInfos.Id, lightSettingInfos.On, lightSettingInfos.Color,
                lightSettingInfos.Brightness);
            this.settingsRepository.UpdateAssignedLightSettings(tagId, deviceId, lightSettings);
            return Ok();
        }
    }
}