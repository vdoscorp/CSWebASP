using WebDI.Services;

namespace WebDI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddSingleton<IHello, HelloImpl>();

            var app = builder.Build();

            app.UseMiddleware<HelloMiddleware>();

            app.Run();
        }
    }
}
