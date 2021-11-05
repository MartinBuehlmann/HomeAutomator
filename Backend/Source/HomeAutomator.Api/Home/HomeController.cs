using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace HomeAutomator.Api.Home
{
    [Microsoft.AspNetCore.Components.Route(ApiConstants.Route)]
    public class HomeController : ApiController
    {
        private readonly IActionContextAccessor actionContextAccessor;
        
        public HomeController(IActionContextAccessor actionContextAccessor)
        {
            this.actionContextAccessor = actionContextAccessor;
        }

        [HttpGet]
        public IActionResult Retrieve()
        {
            HttpContext httpContext = this.actionContextAccessor.ActionContext.HttpContext;

            var url = new StringBuilder()
                .Append(httpContext.Request.Scheme)
                .Append("://")
                .Append(httpContext.Request.Host)
                .Append("/")
                .Append(ApiConstants.Route)
                .Append("/");

            return new JsonResult(
                new ApiHomeInfo(
                    new Url($"{url}devices"),
                    new Url($"{url}nfctags")));
        }
    }
}