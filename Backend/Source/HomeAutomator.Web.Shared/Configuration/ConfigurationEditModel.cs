using System;

namespace HomeAutomator.Web.Shared.Configuration
{
    public class ConfigurationEditModel
    {
        public ConfigurationEditModel(string bridgeId, HueBridgeModel[] discoveredHueBridges)
        {
            BridgeId = bridgeId;
            DiscoveredHueBridges = discoveredHueBridges;
        }

        public string BridgeId { get; set; }

        public HueBridgeModel[] DiscoveredHueBridges { get; }
    }
}