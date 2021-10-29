using HomeAutomator.Hue.Domain;

namespace HomeAutomator.Hue
{
    public interface IHueRepository
    {
        string? RetrieveCurrentBridgeId();

        void SaveOrUpdateCurrentBridgeId(string? bridgeId);

        HueAppRegistration? RetrieveHueAppKeyByBridgeId(string bridgeId);

        void AddOrUpdateHueAppRegistration(HueAppRegistration hueAppRegistration);
    }
}