using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using RedWalker.Core.Domains.Weathers;
using RedWalker.Data.Weathers.Models;

namespace RedWalker.Data.Weathers;

public class WeatherForecast:IWeatherForecast
{
    const string keyWeather = "670034ff5df444799db83147231304";
    private readonly HttpClient _httpClient;

    public WeatherForecast(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<Weather> GetForecast(double lat, double lon)
    {
        string url = String.Format($"?q={lat},{lon}") +  String.Format($"&key={keyWeather}") + "&format=json";
        var response = await _httpClient.GetFromJsonAsync<Response>(url);
        /*var weather = new Weather
        {
            Temperature = 25,
            Cloudcover = 100,
            Precip = 0,
            Visibility = 5,
            Windspeed = 3
        };
        */
        if (!WeatherConstants.CodeToWeatherCondition.TryGetValue(response.data.current_condition[0].weatherCode, out WeatherConstants.WeatherCondition weatherCondtion))
        {
            weatherCondtion = WeatherConstants.WeatherCondition.Other;
        }
        var weather = new Weather
        {
            Temperature = response.data.current_condition[0].temp_C,
            Cloudcover = response.data.current_condition[0].cloudcover,
            Precip = response.data.current_condition[0].precipMM,
            Visibility = response.data.current_condition[0].visibility,
            Windspeed = response.data.current_condition[0].windspeedKmph,
            WeatherCondition = weatherCondtion.ToString()
        };
        

        return weather;
    }
}