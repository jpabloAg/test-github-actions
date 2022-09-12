using forecast.Api;
using ForecastTest.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace ForecastTest
{
    public class WeatherForecastApiTests : ApiBuilder
    {
        private IEnumerable<WeatherForecast> GetForecastSample()
        {
            IEnumerable<WeatherForecast> forecasts = new List<WeatherForecast>()
            {
                new WeatherForecast()
                {
                    Id = "1", Date = DateTime.Parse("2004-10-19 10:23:54+02"), TemperatureC = 248, Summary = "Primavera"
                },
                new WeatherForecast()
                {
                    Id = "2", Date = DateTime.Parse("2022-09-24 08:23:54+00"), TemperatureC = 71, Summary = "Otoño"
                }
            };

            return forecasts;
        }

        [Fact]
        public async Task Get_weatherforecasts_test()
        {
            // Arrange
            IEnumerable<WeatherForecast> forecasts = GetForecastSample();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            // Act
            HttpResponseMessage response = await this.TestClient.GetAsync("/weatherforecast");
            var content = response.Content.ReadAsStringAsync().Result;
            IEnumerable<WeatherForecast> forecastsResponse = JsonSerializer.Deserialize<IEnumerable<WeatherForecast>>(content, options);

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.NotNull(forecastsResponse);
            Assert.True(forecastsResponse.Any());
            Assert.Equal(forecasts.Where(x => x.Id == "1").FirstOrDefault().Summary,
                         forecastsResponse.Where(x => x.Id == "1").FirstOrDefault().Summary);
        }
    }
}
