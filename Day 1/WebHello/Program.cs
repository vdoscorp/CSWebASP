using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;
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

            app.UseExceptionHandler("/error.html");

            app.UseStaticFiles(); // wwwroot
            // MyStatic
            app.UseStaticFiles(new StaticFileOptions() { 
                FileProvider = new PhysicalFileProvider( 
                    Path.Combine(builder.Environment.ContentRootPath, "MyStatic"))
            });

            app.Map("/test", appBuilder => {
                appBuilder.Run(async context =>
                await context.Response.SendFileAsync("test.txt"));
            });

            app.Map("/json", appBuilder => {
                appBuilder.Run(async context =>
                await context.Response.WriteAsJsonAsync(new { Name = "Sergey", Age = 46 }));
            });

            app.Use(async (context, next) => { // First Middleware
                if (context.Request.Method == HttpMethods.Get)
                {
                    //context.Response.WriteAsync("start first Middleware");
                    throw new Exception();
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

            /*app.UseWhen(context => context.Request.Headers.ContainsKey("Time"),
                appBuilder => {
                    appBuilder.Use(async (context, next) =>
                    {
                        await context.Response.WriteAsync("UseWhen() /time");
                        await next();
                    });
                });*/

            app.MapWhen(context => context.Request.Headers.ContainsKey("Time"),
                appBuilder => {
                    appBuilder.Use(async (context, next) =>
                    {
                        await context.Response.WriteAsync("MapWhen() /time");
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
