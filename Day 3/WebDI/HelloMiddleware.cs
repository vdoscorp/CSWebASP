namespace WebDI
{
    public class HelloMiddleware
    {
        private RequestDelegate _next;
        public HelloMiddleware(RequestDelegate next)
        {
            this._next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Response.ContentType = "text/html;charset=utf8";
            await context.Response.WriteAsync("Привет");
            await _next(context);
        }
    }
}
