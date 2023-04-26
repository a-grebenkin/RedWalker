using System.Collections.Generic;

public static class WeatherConstants
{
    public enum WeatherCondition
    {
        ClearDayLight,  //Ясно светлое время суток
        ClearDarkTime, //Ясно темное время суток
        Cloudy, //Пасмурно 
        Rain,   //Дождь
        Fog,    //Туман
        Snowfall,   //Снегопад
        Snowstorm, //Метель
        Other
    }

    public static readonly Dictionary<string, WeatherCondition> CodeToWeatherCondition = new()
        {
            {"113",WeatherCondition.ClearDayLight},
            {"116",WeatherCondition.Cloudy},
            {"119",WeatherCondition.Cloudy},
            {"122",WeatherCondition.Cloudy},
            {"143",WeatherCondition.Fog},
            {"176",WeatherCondition.Rain},
            {"179",WeatherCondition.Snowfall},
            {"182",WeatherCondition.Snowfall},
            {"185",WeatherCondition.Snowfall},
            {"200",WeatherCondition.ClearDayLight},
            {"227",WeatherCondition.Snowstorm},
            {"230",WeatherCondition.Snowstorm},
            {"248",WeatherCondition.Fog},
            {"260",WeatherCondition.Fog},
            {"263",WeatherCondition.Rain},
            {"266",WeatherCondition.Rain},
            {"281",WeatherCondition.Snowfall},
            {"284",WeatherCondition.Snowfall},
            {"293",WeatherCondition.Rain},
            {"296",WeatherCondition.Rain},
            {"299",WeatherCondition.Rain},
            {"302",WeatherCondition.Rain},
            {"305",WeatherCondition.Rain},
            {"308",WeatherCondition.Rain},
            {"311",WeatherCondition.Snowstorm},
            {"314",WeatherCondition.Snowstorm},
            {"317",WeatherCondition.Snowstorm},
            {"320",WeatherCondition.Snowstorm},
            {"323",WeatherCondition.Snowstorm},
            {"326",WeatherCondition.Snowstorm},
            {"329",WeatherCondition.Snowstorm},
            {"332",WeatherCondition.Snowstorm},
            {"335",WeatherCondition.Snowstorm},
            {"338",WeatherCondition.Snowstorm},
            {"350",WeatherCondition.Snowstorm},
            {"353",WeatherCondition.Rain},
            {"356",WeatherCondition.Rain},
            {"359",WeatherCondition.Rain},
            {"362",WeatherCondition.Snowstorm},
            {"365",WeatherCondition.Snowstorm},
            {"368",WeatherCondition.Snowstorm},
            {"371",WeatherCondition.Snowstorm},
            {"374",WeatherCondition.Snowstorm},
            {"377",WeatherCondition.Snowstorm},
            {"386",WeatherCondition.Rain},
            {"389",WeatherCondition.Rain},
            {"392",WeatherCondition.Snowstorm},
            {"395",WeatherCondition.Snowstorm}
        };
}