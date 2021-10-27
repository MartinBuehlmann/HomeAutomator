using System.Collections.Generic;
using System.Threading.Tasks;
using HomeAutomator.Hue.HueItems;

namespace HomeAutomator.Hue
{
    public interface IHueService
    {
        Task<IReadOnlyList<HueBridge>> DiscoverBridgesAsync();

        Task<HueAppKey> RegisterAppAsync(HueBridge bridge, string appName, string deviceName);
    }
}