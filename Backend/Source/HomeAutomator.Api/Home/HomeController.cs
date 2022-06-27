namespace HomeAutomator.Api.Home
{
    using HomeAutomator.Api.Automator;
    using HomeAutomator.Api.Devices;
    using HomeAutomator.Api.Lights;
    using HomeAutomator.Api.NfcTags;
    using HomeAutomator.Api.Settings;
    using Microsoft.AspNetCore.Mvc;

    [Route(ApiConstants.Route)]
    public class HomeController : ApiController
    {
        private readonly UrlBuilder urlBuilder;

        public HomeController(UrlBuilder urlBuilder)
        {
            this.urlBuilder = urlBuilder;
        }

        [HttpGet]
        public ApiHomeInfo Retrieve()
        {
            return new ApiHomeInfo(
                    new Url(this.urlBuilder.Build(ApiConstants.Route, nameof(AutomatorController))),
                    new Url(this.urlBuilder.Build(ApiConstants.Route, nameof(DevicesController))),
                    new Url(this.urlBuilder.Build(ApiConstants.Route, nameof(NfcTagsController))),
                    new Url(this.urlBuilder.Build(ApiConstants.Route, nameof(SettingsController))),
                    new Url(this.urlBuilder.Build(ApiConstants.Route, nameof(LightsController))));
        }
    }
}