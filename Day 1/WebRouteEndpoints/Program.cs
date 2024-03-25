using System.Collections.Generic;
using System.Net;

namespace WebRouteEndpoints
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            /*
            app.UseRouting();

            app.UseEndpoints(endpoints => {
                endpoints.MapGet("/api/people",async context => 
                    context.Response.WriteAsJsonAsync(Person.All));
                endpoints.MapGet("/api/person/{id:int}", async context =>
                    context.Response.WriteAsJsonAsync(Person.All));
            });*/

            app.MapGet("/api/people", async context =>
                await context.Response.WriteAsJsonAsync(Person.All));
            app.MapGet("/api/person/{id:int}", async (HttpContext context,int id) =>
            {
            Person p = Person.All.Where(p => p.Id == id).SingleOrDefault();
                if (p != null)
                    await context.Response.WriteAsJsonAsync(p);
                else
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            });
            app.MapGet("/api/person/{search}", async (HttpContext context, string search) =>
            {
                var list = Person.All.Where(p => p.Name.Contains(search)).ToList();
                if (list.Any())
                    await context.Response.WriteAsJsonAsync(list);
                else
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            });
            app.MapDelete("api/person/{id:int}", async (HttpContext context, int id) =>
            {
                Person p = Person.All.Where(p => p.Id == id).SingleOrDefault();
                if (p != null)
                {
                    Person.All.Remove(p);
                    context.Response.StatusCode = (int)HttpStatusCode.OK;
                }
                else
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            });

            app.MapPost("api/person", async (HttpContext context, Person p) =>
            {
                p.Id = Person.All.Select(p => p.Id).Max()+1;
                Person.All.Add(p);
                await context.Response.WriteAsJsonAsync(p);
            });

            app.Run();
        }
    }
}
