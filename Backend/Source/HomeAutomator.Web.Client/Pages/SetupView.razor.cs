namespace HomeAutomator.Web.Client.Pages;

using System.Threading.Tasks;

/// <summary>
/// Code behind of the setup view.
/// </summary>
public partial class SetupView
{
    protected override async Task OnInitializedAsync()
    {
        await this.ViewModel.OnInitializedAsync();
    }
}