using System.Runtime.InteropServices;
using WebDI.Services;

namespace WebDI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //builder.Services.AddSingleton<IHello, HelloImpl>();

            var app = builder.Build();

            /*app.Run(async context => {
                context.Response.ContentType = "text/html;charset=utf8";
                await context.Response.WriteAsync(app.Services.GetService<IHello>().GetHelloString());
            });*/

            app.UseMiddleware<HelloMiddleware>();

            app.Run();
        }
    }
}
