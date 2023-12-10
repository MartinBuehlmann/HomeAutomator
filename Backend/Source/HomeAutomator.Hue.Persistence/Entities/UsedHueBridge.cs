namespace HomeAutomator.Hue.Persistence.Entities;

internal class UsedHueBridge
{
    public UsedHueBridge(string? bridgeId)
    {
        this.BridgeId = bridgeId;
    }

    public string? BridgeId { get; }
}