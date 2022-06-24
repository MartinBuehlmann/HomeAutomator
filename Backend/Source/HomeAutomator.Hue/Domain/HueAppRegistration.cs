namespace HomeAutomator.Hue.Domain
{
    public class HueAppRegistration
    {
        public HueAppRegistration(string bridgeId, string appKey)
        {
            this.BridgeId = bridgeId;
            this.AppKey = appKey;
        }

        public string BridgeId { get; }

        public string AppKey { get; }
    }
}