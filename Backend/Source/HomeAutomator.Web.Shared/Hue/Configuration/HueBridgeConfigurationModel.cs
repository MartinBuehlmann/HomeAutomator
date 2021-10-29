using System;

namespace HomeAutomator.Web.Shared.Hue.Configuration
{
    public class HueBridgeConfigurationModel
    {
        public HueBridgeConfigurationModel()
        {
            this.DiscoveredHueBridges = Array.Empty<HueBridgeModel>();
        }

        public string? Id { get; set; }

        public HueBridgeModel[] DiscoveredHueBridges { get; set; }
    }
}