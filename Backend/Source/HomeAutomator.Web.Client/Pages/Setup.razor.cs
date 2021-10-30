using System;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using HomeAutomator.Web.Shared.Configuration;

namespace HomeAutomator.Web.Client.Pages
{
    public partial class Setup
    {
        private string selectedBridgeId = string.Empty;

        [Inject]
        private HttpClient? Http { get; set; }

        public string SelectedBridgeId
        {
            get => selectedBridgeId;
            set
            {
                selectedBridgeId = value;
                this.CanUseSelectedBridge = !string.IsNullOrEmpty(selectedBridgeId);
            }
        }

        public HueBridgeModel[] DiscoveredHueBridges { get; set; } = Array.Empty<HueBridgeModel>();

        public bool CanUseSelectedBridge { get; set; }

        protected override async Task OnInitializedAsync()
        {
            ConfigurationEditModel? bridgeConfiguration = await this.Http!.GetFromJsonAsync<ConfigurationEditModel>("Web/Hue/Configuration");

            if (bridgeConfiguration != null)
            {
                this.SelectedBridgeId = bridgeConfiguration.BridgeId;
                this.DiscoveredHueBridges = bridgeConfiguration.DiscoveredHueBridges;
            }
        }

        private async Task UseSelectedBridge()
        {
            await this.Http!.PostAsJsonAsync("Web/Hue/Configuration", new ConfigurationSaveModel(SelectedBridgeId));
        }
    }
}
