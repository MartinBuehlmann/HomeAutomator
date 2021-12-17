namespace HomeAutomator.Web.Shared.Configuration;

public class ConfigurationSaveModel
{
    public ConfigurationSaveModel(string bridgeId)
    {
        this.BridgeId = bridgeId;
    }

    public string BridgeId { get; }
}