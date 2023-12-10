namespace HomeAutomator.Hue.Domain;

public class HueBridge
{
    public HueBridge(string bridgeId, string ipAddress)
    {
        this.BridgeId = bridgeId;
        this.IpAddress = ipAddress;
    }

    public string BridgeId { get; }

    public string IpAddress { get; }
}