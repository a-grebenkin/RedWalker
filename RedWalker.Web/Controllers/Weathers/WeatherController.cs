using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RedWalker.Core.Domains.Weathers;
using RedWalker.Web.Controllers.Weathers.Dto;

namespace RedWalker.Web.Controllers.Weathers;

[ApiController]
[Route("[controller]")]
public class WeatherController:ControllerBase
{
    private readonly IWeatherForecast _weatherForecast;

    public WeatherController(IWeatherForecast weatherForecast)
    {
        _weatherForecast = weatherForecast;
    }

    [HttpGet]
    public async Task<WeatherDto> GetByLatLon(double lat, double lon)
    {
        var weather = await _weatherForecast.GetForecast(lat, lon);
        return new WeatherDto
        {
            Temperature = weather.Temperature,
            Cloudcover = weather.Cloudcover,
            Precip = weather.Precip,
            Visibility = weather.Visibility,
            Windspeed = weather.Windspeed
        };
    }
}