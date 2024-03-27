using WebDI.Services;

namespace WebDI
{
    public class HelloMiddleware
    {
        private RequestDelegate _next;
        private IHello helloSrv;

        public HelloMiddleware(RequestDelegate next, IHello hello)
        {
            this._next = next;
            this.helloSrv=hello;
        }

        public async Task Invoke(HttpContext context)
        {
            context.Response.ContentType = "text/html;charset=utf8";
            //await context.Response.WriteAsync(helloSrv.GetHelloString());
            IHello helloSrv2 = context.RequestServices.GetRequiredService<IHello>();
            await context.Response.WriteAsync(helloSrv2.GetHelloString());
            await _next(context);
        }
    }
}
