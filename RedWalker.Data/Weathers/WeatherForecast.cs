using System;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using RedWalker.Core.Domains.Weathers;
using RedWalker.Data.Weathers.Models;

namespace RedWalker.Data.Weathers;

public class WeatherForecast:IWeatherForecast
{
    const string keyWeather = "f3f23b92df7e478ebf8140219231906";
    private readonly HttpClient _httpClient;

    public WeatherForecast(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<WeatherModel> GetForecast(double lat, double lon)
    {
        string url = String.Format($"?q={lat},{lon}") +  String.Format($"&key={keyWeather}") + "&format=json";
        var response = await _httpClient.GetFromJsonAsync<Response>(url);
        if (!WeatherConstants.CodeToWeatherCondition.TryGetValue(response.data.current_condition[0].weatherCode, out WeatherConstants.WeatherCondition weatherCondtion))
        {
            weatherCondtion = WeatherConstants.WeatherCondition.Other;
        }
        
        var weather = new WeatherModel
        {
            Temperature = response.data.current_condition[0].temp_C,
            Cloudcover = response.data.current_condition[0].cloudcover,
            Precip = response.data.current_condition[0].precipMM,
            Visibility = response.data.current_condition[0].visibility,
            Windspeed = response.data.current_condition[0].windspeedKmph,
            WeatherCondition = weatherCondtion.ToString(),
            TimeSunrise =  DateTime.ParseExact(response.data.weather[0].date +" "+ response.data.weather[0].astronomy[0].sunrise, "yyyy-MM-dd hh:mm tt", CultureInfo.InvariantCulture),
            TimeSunset = DateTime.ParseExact(response.data.weather[0].date + " "+ response.data.weather[0].astronomy[0].sunset, "yyyy-MM-dd hh:mm tt", CultureInfo.InvariantCulture)
        };
        var dateTimeNow = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "N. Central Asia Standard Time");
        if (weather.WeatherCondition == WeatherConstants.WeatherCondition.ClearDayLight.ToString() && 
            (dateTimeNow < weather.TimeSunrise || dateTimeNow > weather.TimeSunset))
        {
            weather.WeatherCondition = WeatherConstants.WeatherCondition.ClearDarkTime.ToString();
        }

        return weather;
    }
}