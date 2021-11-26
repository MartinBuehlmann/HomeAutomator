using HomeAutomator.Api.Devices;
using HomeAutomator.Api.Lights;
using HomeAutomator.Api.NfcTags;
using HomeAutomator.Api.Settings;
using Microsoft.AspNetCore.Mvc;

namespace HomeAutomator.Api.Home
{
    [Route(ApiConstants.Route)]
    public class HomeController : ApiController
    {
        private readonly UrlBuilder urlBuilder;

        public HomeController(UrlBuilder urlBuilder)
        {
            this.urlBuilder = urlBuilder;
        }

        [HttpGet]
        public IActionResult Retrieve()
        {
                return new JsonResult(
                    new ApiHomeInfo(
                        new Url(this.urlBuilder.Build(ApiConstants.Route, nameof(DevicesController))),
                        new Url(this.urlBuilder.Build(ApiConstants.Route, nameof(NfcTagsController))),
                        new Url(this.urlBuilder.Build(ApiConstants.Route, nameof(SettingsController))),
                        new Url(this.urlBuilder.Build(ApiConstants.Route, nameof(LightsController)))));
        }
    }
}