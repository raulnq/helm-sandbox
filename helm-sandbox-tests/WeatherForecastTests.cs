using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace helm_sandbox_tests
{
    [TestClass]
    public class WeatherForecastTests
    {
        private readonly string _uri;

        [TestMethod]
        public async Task should_return_ok()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_uri);

                var response = await client.GetAsync("WeatherForecast");

                Assert.IsNotNull(response);

                Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            }
        }

        public WeatherForecastTests()
        {
            var config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true)
            .AddEnvironmentVariables()
            .Build();

            _uri = config["Uri"];
        }
    }
}