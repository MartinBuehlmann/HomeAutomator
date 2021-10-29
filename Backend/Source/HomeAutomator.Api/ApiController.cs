using Microsoft.AspNetCore.Mvc;

namespace HomeAutomator.Api
{
    [ApiExplorerSettings(GroupName = ApiConstants.Route)]
    [Route(ApiConstants.Route + "/[controller]")]
    [Consumes("application/json")]
    public abstract class ApiController : Controller
    {
    }
}
