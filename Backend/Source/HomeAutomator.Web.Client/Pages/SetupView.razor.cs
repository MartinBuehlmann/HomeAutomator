namespace HomeAutomator.Web.Client.Pages;

using System.Threading.Tasks;

public partial class SetupView
{
    protected override async Task OnInitializedAsync()
    {
        await this.viewModel.OnInitializedAsync();
    }
}