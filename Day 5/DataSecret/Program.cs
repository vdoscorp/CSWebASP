using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


using IHost host = Host.CreateDefaultBuilder(args)
    .UseEnvironment("Development")
    .Build();
IConfiguration config = host.Services.GetRequiredService<IConfiguration>();
string value_1 = config["Key_ONE"];
string value_2 = config["Key_TWO"];

Console.WriteLine($"KeyOne = {value_1}");
Console.WriteLine($"KeyTwo = {value_2}");

//await host.RunAsync();