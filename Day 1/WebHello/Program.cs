namespace WebHello
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(
                new WebApplicationOptions(){ Args = args });

            var app = builder.Build();

            //app.MapGet("/", () => "<h1>Hello World!</h1>");
            app.Use(async (context, next) =>
            {
                if (context.Request.Method == HttpMethods.Get)
                {
                    context.Response.WriteAsync("start first Middleware");
                }
                await context.Response.WriteAsync("end first Middleware");
                await next();
                
            });

            app.Run();
        }
    }
}
