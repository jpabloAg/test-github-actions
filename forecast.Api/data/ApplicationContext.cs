using Microsoft.EntityFrameworkCore;

namespace forecast.Api.data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
    }
}
