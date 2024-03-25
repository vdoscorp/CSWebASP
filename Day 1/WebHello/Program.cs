using Microsoft.AspNetCore.Builder;
using System.ComponentModel.Design.Serialization;
using System.Net;

namespace WebHello
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(
                new WebApplicationOptions() { Args = args });

            var app = builder.Build();

            app.Use(async (context, next) => { // First Middleware
                if (context.Request.Method == HttpMethods.Get)
                {
                    context.Response.WriteAsync("start first Middleware");
                }
                await next();
                await context.Response.WriteAsync("end first Middleware");
            });

            app.Map("/security", appBuilder =>
            {
                // /security/login
                appBuilder.Map("/login", async ab2 =>
                    { ab2.Run(async context => await context.Response.WriteAsync("Login page.")); });
                // /security/register
                appBuilder.Map("/register", async ab2 =>
                    { ab2.Run(async context => await context.Response.WriteAsync("Register page.")); });
            });

            app.Map("/date", appBuilder => {
                appBuilder.Run(async context =>
                await context.Response.WriteAsync($"Server time: {DateTime.Now.ToShortDateString()}"));
            });

            //app.MapGet("/", () => "<h1>Hello World!</h1>");


            app.UseMiddleware<SecondMiddleware>();

            app.UseWhen(context => context.Request.Path == "/time",
                appBuilder => {
                    appBuilder.Use(async (context, next) =>
                    {
                        await context.Response.WriteAsync("UseWhen() /time");
                        await next();
                    });
                });

            //Third middleware (terminal)
            app.Run(async context => {
                context.Response.WriteAsync("Hello from Run(...)");
            });

            app.Run();
        }
    }
}
