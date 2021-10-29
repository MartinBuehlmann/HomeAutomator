namespace HomeAutomator.Hue.Persistence.Entities
{
    public class UsedHueBridge
    {
        public UsedHueBridge(string? bridgeId)
        {
            BridgeId = bridgeId;
        }

        public string? BridgeId { get; }
    }
}