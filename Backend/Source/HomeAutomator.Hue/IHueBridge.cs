namespace HomeAutomator.Hue;

using System.Collections.Generic;
using System.Threading.Tasks;
using HomeAutomator.Hue.Domain;

public interface IHueBridge
{
    Task<IReadOnlyList<HueBridge>> DiscoverBridgesAsync();

    Task<HueAppRegistration?> RegisterAppAsync(HueBridge bridge, string appName, string deviceName);

    Task<IReadOnlyList<HueLight>> RetrieveLightsAsync();

    Task SetLightAsync(HueLight light);

    Task<IReadOnlyList<HueGroup>> RetrieveGroupsAsync();
}