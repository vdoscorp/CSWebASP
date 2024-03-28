using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebMVC.Filters
{
    public class ExFilter : IExceptionFilter
    {
        private IHostEnvironment env;

        public ExFilter(IHostEnvironment env) => this.env = env;

        public void OnException(ExceptionContext context)
        {
            if (env.IsDevelopment())
                context.Result = new ContentResult()
                {
                    Content = context.Exception.ToString()
                };
            else
                if (env.IsProduction())
                context.Result = new RedirectToActionResult("Error", "Home", null);
            else
                context.Result = new ContentResult()
                {
                    Content = "Internal error, call administrator"
                };
        }
    }
}
