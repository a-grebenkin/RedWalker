using System;

namespace RedWalker.Core.Domains.Weathers;

public class WeatherApproximator : IWeatherApproximator
{
    private const double maxError = 0.01;
    
    private const double maxTempDiff = 100;
    private const double maxCloudDiff = 100;
    private const double maxVisibilDiff = 10;
    private const double maxPrecipDiff = 15;
    private const double macWindDiff = 100;
    private double DiffStand(double value1, double value2, double maxValue) => Math.Pow((value1 - value2)/maxValue,2);
    public bool Approximate(Weather weatherCondition1, Weather weatherCondition2)
    {
        var tempDiffStand = DiffStand(weatherCondition1.Temperature, weatherCondition2.Temperature, maxTempDiff);
        var cloudDiffStand = DiffStand(weatherCondition1.Cloudcover, weatherCondition2.Cloudcover, maxCloudDiff);
        var precipDiffStand= DiffStand(weatherCondition1.Precip, weatherCondition2.Precip, maxVisibilDiff);
        var visibilDiffStand = DiffStand(weatherCondition1.Visibility, weatherCondition2.Visibility, maxPrecipDiff);
        var windDiffStand = DiffStand(weatherCondition1.Windspeed, weatherCondition2.Windspeed, macWindDiff);
        
        var error = tempDiffStand + cloudDiffStand + precipDiffStand + visibilDiffStand + windDiffStand;
        if (error > maxError)
        {
            return false;
        }
        return true;
    }
}