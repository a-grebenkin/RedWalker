using System.Threading.Tasks;

namespace RedWalker.Core.Domains.Weathers;

public interface IWeatherForecast
{
    public Task<WeatherModel> GetForecast(double lat, double lon);
}