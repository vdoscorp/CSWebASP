namespace WebHello
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(
                new WebApplicationOptions(){ Args = args });

            var app = builder.Build();

            app.Use(async (context, next) => { // First Middleware
                if (context.Request.Method == HttpMethods.Get)
                {
                    context.Response.WriteAsync("start first Middleware");
                }
                await next();
                await context.Response.WriteAsync("end first Middleware");
            });

            app.Map("/date", appBuilder => {
                appBuilder.Run(async context =>
                await context.Response.WriteAsync($"Server time: {DateTime.Now.ToShortDateString()}"));
            });

           //app.MapGet("/", () => "<h1>Hello World!</h1>");


            app.UseMiddleware<SecondMiddleware>();

            //Third middleware (terminal)
            app.Run(context => context.Response.WriteAsync("Hello from Run(...)"));

            app.Run();
        }
    }
}
