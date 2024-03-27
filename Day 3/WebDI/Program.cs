using System.Runtime.InteropServices;
using WebDI.Services;

namespace WebDI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddSingleton<IHello, HelloImpl>();
            builder.Services.AddTransient<ICounter, CounterImpl>();

            var app = builder.Build();

            /*app.Run(async context => {
                context.Response.ContentType = "text/html;charset=utf8";
                await context.Response.WriteAsync(app.Services.GetService<IHello>().GetHelloString());
            });*/

            app.UseMiddleware<HelloMiddleware>();

            app.Use(async (context, next) => {
                var counter = app.Services.GetRequiredService<ICounter>();
                counter.Increment();
                await context.Response.WriteAsync($"<h2>{counter.Get()}<h2>");

                await next();
            });

            app.Run();
        }
    }
}
