using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;
using System.Net;

namespace WebHello.Test
{
    public class MiddlewareTest
    {
        [Fact]
        public async void SecondMiddlewareResponseTest()
        {
            //Arrange
            using var host = await new HostBuilder()
                .ConfigureWebHost(webBuilder =>
                {
                    webBuilder.UseTestServer()

                    //.ConfigureServices(services => services.AddMyService())

                    .Configure(app => app.UseMiddleware<SecondMiddleware>());
                }).StartAsync();

            // Act
            var response = await host.GetTestClient().GetAsync("/");

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Contains("Status code =", await response.Content.ReadAsStringAsync());
        }
    }
}