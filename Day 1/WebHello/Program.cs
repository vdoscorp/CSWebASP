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

            app.UseStaticFiles(); // wwwroot
            
            app.Map("/date", appBuilder => {
                appBuilder.Run(async context =>
                await context.Response.WriteAsync($"Server date: {DateTime.Now.ToShortDateString()}"));
            });

            app.Map("/time", appBuilder => {
                appBuilder.Run(async context =>
                await context.Response.WriteAsync($"Server time: {DateTime.Now.ToShortTimeString()}"));
            });

            //Third middleware (terminal)
            app.Run(async context => {
                context.Response.WriteAsync("Page not found");
            });

            app.Run();
        }
    }
}
