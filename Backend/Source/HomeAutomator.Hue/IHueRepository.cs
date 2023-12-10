namespace HomeAutomator.Hue;

using HomeAutomator.Hue.Domain;

public interface IHueRepository
{
    string? RetrieveCurrentBridgeId();

    void SaveOrUpdateCurrentBridgeId(string? bridgeId);

    HueAppRegistration? RetrieveHueAppKeyByBridgeId(string bridgeId);

    void AddOrUpdateHueAppRegistration(HueAppRegistration hueAppRegistration);
}