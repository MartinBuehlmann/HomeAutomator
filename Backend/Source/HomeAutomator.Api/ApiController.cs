using Microsoft.AspNetCore.Mvc;

namespace HomeAutomator.Api
{
    [Route(ApiConstants.Route + "/[controller]")]
    [Consumes("application/json")]
    public abstract class ApiController : Controller
    {
    }
}
