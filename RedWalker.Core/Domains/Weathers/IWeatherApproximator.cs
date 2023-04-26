using System;

namespace RedWalker.Core.Domains.Weathers;

public interface IWeatherApproximator
{
    public bool Approximate(WeatherModel weatherModel1, WeatherModel weatherModel2, DateTime time1, DateTime time2);
}