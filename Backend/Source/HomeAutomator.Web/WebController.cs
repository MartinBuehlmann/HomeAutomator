using Microsoft.AspNetCore.Mvc;

namespace HomeAutomator.Web
{
    [ApiExplorerSettings(GroupName = WebConstants.Route)]
    [Route(WebConstants.Route + "/[controller]")]
    [Consumes("application/json")]
    public abstract class WebController : Controller
    {
    }
}
