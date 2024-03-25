namespace WebRouteEndpoints
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var app = builder.Build();

            app.UseRouting();

            app.UseEndpoints(endpoints => {
                endpoints.MapGet("/api/people",async context => 
                    context.Response.WriteAsJsonAsync(Person.All));
                endpoints.MapGet("/api/person/{id:int}", async context =>
                    context.Response.WriteAsJsonAsync(Person.All));
            });

            app.Run();
        }
    }
}
