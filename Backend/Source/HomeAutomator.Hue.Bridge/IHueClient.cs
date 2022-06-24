namespace HomeAutomator.Hue.Bridge
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using HomeAutomator.Hue.Domain;

    internal interface IHueClient
    {
        Task<IReadOnlyList<HueLight>> RetrieveLightsAsync();

        Task SetLightAsync(HueLight light);

        Task<IReadOnlyList<HueGroup>> RetrieveRoomsAsync();
    }
}