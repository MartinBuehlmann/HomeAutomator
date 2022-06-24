namespace HomeAutomator.Api
{
    using System;
    using System.Text;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc.Infrastructure;

    public class UrlBuilder
    {
        private readonly IActionContextAccessor actionContextAccessor;

        public UrlBuilder(IActionContextAccessor actionContextAccessor)
        {
            this.actionContextAccessor = actionContextAccessor;
        }

        public string Build(string routeName, string controller, string? resourceIdentifier = null)
        {
            const string ControllerAppendix = "Controller";
            HttpContext httpContext = this.actionContextAccessor.ActionContext!.HttpContext;

            var url = new StringBuilder()
                .Append(httpContext.Request.Scheme)
                .Append("://")
                .Append(httpContext.Request.Host);

            if (!string.IsNullOrEmpty(routeName))
            {
                url.Append('/');
                url.Append(routeName);
            }

            if (!string.IsNullOrEmpty(controller))
            {
                if (controller.EndsWith(ControllerAppendix, StringComparison.OrdinalIgnoreCase))
                {
                    controller = controller.Substring(0, controller.Length - ControllerAppendix.Length);
                }

                url.Append('/');
                url.Append(controller);
            }

            if (resourceIdentifier != null)
            {
                url.Append('/');
                url.Append(resourceIdentifier);
            }

            if (url.Length == 0)
            {
                url.Append('/');
            }

            return url.ToString();
        }
    }
}