using System;
using System.IO;

namespace RedWalker.Core.Domains.Weathers;

public class ConditionApproximator : IConditionApproximator
{
    private const double diffWeatherCondition = 100;
        
    private const double maxTempDiff = 100;
    private const double maxCloudDiff = 100;
    private const double maxVisibilDiff = 10;
    private const double maxPrecipDiff = 15;
    private const double maxWindDiff = 100;
    private double DiffStand(double value1, double value2, double maxValue) => Math.Pow((value1 - value2)/maxValue,2);
    private double DiffStand(double value, double maxValue) => Math.Pow(value/maxValue,2);
    public double Approximate(WeatherModel weatherModel1, WeatherModel weatherModel2, DateTime time1, DateTime time2)
    {
        if (weatherModel1.WeatherCondition != weatherModel2.WeatherCondition)
        {
            return diffWeatherCondition;
        }
        var tempDiffStand = DiffStand(weatherModel1.Temperature, weatherModel2.Temperature, maxTempDiff);
        var cloudDiffStand = DiffStand(weatherModel1.Cloudcover, weatherModel2.Cloudcover, maxCloudDiff);
        var precipDiffStand= DiffStand(weatherModel1.Precip, weatherModel2.Precip, maxVisibilDiff);
        var visibilDiffStand = DiffStand(weatherModel1.Visibility, weatherModel2.Visibility, maxPrecipDiff);
        var windDiffStand = DiffStand(weatherModel1.Windspeed, weatherModel2.Windspeed, maxWindDiff);


        var durationDayMinutes1 = (weatherModel1.TimeSunset - weatherModel1.TimeSunrise).TotalMinutes;
        var durationNightMinutes1 = (weatherModel1.TimeSunrise - weatherModel1.TimeSunset).Duration().TotalMinutes;
        var durationDayMinutes2 = (weatherModel2.TimeSunset - weatherModel2.TimeSunrise).TotalMinutes;
        var durationNightMinutes2 = (weatherModel2.TimeSunrise - weatherModel2.TimeSunset).Duration().TotalMinutes;
        
            
        var intervalSunriseMinutes1 = (time1 - weatherModel1.TimeSunrise).TotalMinutes;
        var intervalSunsetMinutes1 = (time1 - weatherModel1.TimeSunset).TotalMinutes;
        var intervalSunriseMinutes2 = (time2 - weatherModel2.TimeSunrise).TotalMinutes;
        var intervalSunsetMinutes2 = (time2 - weatherModel2.TimeSunset).TotalMinutes;

        double standIntervalSunrise1;
        double standIntervalSunset1;
        //проверка на то что сейчас ночь (день либо не начался либо уже закончился)
        if ((intervalSunriseMinutes1 < 0 && intervalSunsetMinutes1 < 0) ||
            (intervalSunriseMinutes1 > 0 && intervalSunsetMinutes1 > 0))
        {
            //используем для стандартизации продолжительность ночи
            standIntervalSunrise1 =  intervalSunriseMinutes1 /(durationNightMinutes1/2);
            standIntervalSunset1 =  intervalSunsetMinutes1 / (durationNightMinutes1/2);
        }
        //иначе сейчас день
        else
        {
            //используем для стандартизации продолжительность дня
            standIntervalSunrise1 = intervalSunriseMinutes1 /(durationDayMinutes1/2);
            standIntervalSunset1 = intervalSunsetMinutes1 / (durationDayMinutes1/2);
        }
        
        //аналогично для 2 
        double standIntervalSunrise2;
        double standIntervalSunset2;
        if ((intervalSunriseMinutes2 < 0 && intervalSunsetMinutes2 < 0) ||
            (intervalSunriseMinutes2 > 0 && intervalSunsetMinutes2 > 0))
        {
            standIntervalSunrise2 = intervalSunriseMinutes2 / (durationNightMinutes2/2);
            standIntervalSunset2 = intervalSunsetMinutes2 / (durationNightMinutes2/2);
        }
        else
        {
            standIntervalSunrise2 = intervalSunriseMinutes2 /(durationDayMinutes2/2);
            standIntervalSunset2 = intervalSunsetMinutes2 /(durationDayMinutes2/2);
        }

        //берем наименьшую разность по модулю в качестве стандартизированной ошибки времени
        var diffStandIntervalSunrise = Math.Pow(standIntervalSunrise1 - standIntervalSunrise2,2);
        var diffStandIntervalSunset = Math.Pow(standIntervalSunset1 - standIntervalSunset2,2);
        var timeDiffStand = diffStandIntervalSunrise < diffStandIntervalSunset ? diffStandIntervalSunrise : diffStandIntervalSunset;
        
        var error = tempDiffStand + cloudDiffStand + precipDiffStand + visibilDiffStand + windDiffStand + timeDiffStand;
        using (var writer = new StreamWriter("log1.txt",append: true))
        {
            writer.WriteLine(error);
        }
        return error;
    }
}