using System.Net;

namespace WebRouteEndpoints
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.UseRouting();

            /*app.UseEndpoints(endpoints => {
                endpoints.MapGet("/api/people",async context => 
                    context.Response.WriteAsJsonAsync(Person.All));
                endpoints.MapGet("/api/person/{id:int}", async context =>
                    context.Response.WriteAsJsonAsync(Person.All));
            });*/

            app.MapGet("/api/people", async context =>
                await context.Response.WriteAsJsonAsync(Person.All));
            app.MapGet("/api/person/{name}", async (HttpContext context,string name) =>
            {
            var list = Person.All.Where(p => p.Name == name).ToList();
                if (list.Any())
                    await context.Response.WriteAsJsonAsync(list);
                else
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            });
            
            app.Run();
        }
    }
}
