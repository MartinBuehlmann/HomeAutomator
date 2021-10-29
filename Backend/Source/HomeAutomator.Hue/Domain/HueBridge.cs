namespace HomeAutomator.Hue.Domain
{
    public class HueBridge
    {
        public HueBridge(string bridgeId, string ipAddress)
        {
            BridgeId = bridgeId;
            IpAddress = ipAddress;
        }

        public string BridgeId { get; }

        public string IpAddress { get; }
    }
}