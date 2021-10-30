namespace HomeAutomator.Web.Shared.Configuration
{
    public class ConfigurationSaveModel
    {
        public ConfigurationSaveModel(string bridgeId)
        {
            BridgeId = bridgeId;
        }

        public string BridgeId { get; }
    }
}