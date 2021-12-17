namespace HomeAutomator.Api;

using Microsoft.AspNetCore.Mvc;

[ApiExplorerSettings(GroupName = ApiConstants.Route)]
[Route(ApiConstants.Route + "/[controller]")]
[Consumes("application/json")]
public abstract class ApiController : Controller
{
}