using System;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using HomeAutomator.Web.Shared.Hue.Configuration;

namespace HomeAutomator.Web.Client.Pages
{
    public partial class Setup
    {
        [Inject]
        private HttpClient? Http { get; set; }

        public HueBridgeConfigurationModel? BridgeConfiguration { get; set; }
        
        protected override async Task OnInitializedAsync()
        {
            this.BridgeConfiguration = await this.Http!.GetFromJsonAsync<HueBridgeConfigurationModel>("Web/Hue/Configuration");
        }

        private async Task UseSelectedBridge()
        {
            if (!string.IsNullOrEmpty(this.BridgeConfiguration?.Id))
            {
                await this.Http!.PostAsJsonAsync("Web/Hue/Configuration", this.BridgeConfiguration?.Id);
            }
        }
    }
}
