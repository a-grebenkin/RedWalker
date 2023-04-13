namespace RedWalker.Core.Domains.Weathers;

public interface IWeatherApproximator
{
    public bool Approximate(Weathers.Weather weatherCondition1, Weathers.Weather weatherCondition2);
}