using forecast.Api.data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace forecast.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ApplicationContext _context;

    public WeatherForecastController(ApplicationContext context)
    {
        _context = context;
    }

    [HttpGet()]
    public async Task<ActionResult<IEnumerable<WeatherForecast>>> Get()
    {
        var forecasts = await _context.WeatherForecasts.ToListAsync();
        return Ok(forecasts);
    }

    [HttpPost()]
    public async Task<ActionResult<string>> Post(WeatherForecast weather)
    {
        await _context.WeatherForecasts.AddAsync(weather);
        await _context.SaveChangesAsync();
        return weather.Id;
    }
}
