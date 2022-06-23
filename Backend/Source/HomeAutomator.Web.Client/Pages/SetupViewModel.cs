namespace HomeAutomator.Web.Client.Pages;

using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using HomeAutomator.Web.Shared.Configuration;

internal class SetupViewModel
{
    private readonly HttpClient http;
    private string selectedBridgeId = string.Empty;

    public SetupViewModel(HttpClient http)
    {
        this.http = http;
    }

    public string SelectedBridgeId
    {
        get => this.selectedBridgeId;
        set
        {
            this.selectedBridgeId = value;
            this.CanUseSelectedBridge = !string.IsNullOrEmpty(this.selectedBridgeId);
        }
    }

    public bool CanUseSelectedBridge { get; set; }

    public HueBridgeModel[] DiscoveredHueBridges { get; set; } = Array.Empty<HueBridgeModel>();

    public async Task OnInitializedAsync()
    {
        var bridgeConfiguration = await this.http.GetFromJsonAsync<ConfigurationEditModel>("Web/Hue/Configuration");

        if (bridgeConfiguration != null)
        {
            this.SelectedBridgeId = bridgeConfiguration.BridgeId;
            this.DiscoveredHueBridges = bridgeConfiguration.DiscoveredHueBridges;
        }
    }

    public async Task UseSelectedBridgeAsync()
    {
        await this.http.PostAsJsonAsync("Web/Hue/Configuration", new ConfigurationSaveModel(this.SelectedBridgeId));
    }
}