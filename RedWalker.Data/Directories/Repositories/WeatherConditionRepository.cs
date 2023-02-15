using System;
using System.Collections.Generic;
using System.Linq;
using RedWalker.Core.Domains.Accidents;
using RedWalker.Core.Domains.Directories;
using RedWalker.Core.Domains.Directories.Repositories;

namespace RedWalker.Data.Directories.Repositories;

public class WeatherConditionRepository:IWeatherConditionRepository
{
    private enum WeatherCondition
    {
        Clear,  //Ясно
        Сloudy, //Пасмурно 
        Rain,   //Дождь
        Fog,    //Туман
        Snowfall,   //Снегопад
        Snowstorm //Метель
    }

    private static readonly Dictionary<WeatherCondition, string> DictWeatherCondition = new(){
        {WeatherCondition.Clear, "Ясно"},
        {WeatherCondition.Сloudy, "Пасмурно"},
        {WeatherCondition.Rain, "Дождь"},
        {WeatherCondition.Fog, "Туман"},
        {WeatherCondition.Snowfall, "Снегопад"},
        {WeatherCondition.Snowstorm, "Метель"}
    };
    public List<Directory> GetAll()
    {
        return DictWeatherCondition.Select(dict => new Directory
        {
            Id = dict.Key.ToString(),
            Name = dict.Value
        }).ToList();
    }

    public Directory GetById(string id)
    {
        if (!Enum.TryParse(id, out WeatherCondition key))
        {
            return null;
        }
        if (!DictWeatherCondition.TryGetValue(key, out var typeAccident))
        {
            return null;
        }

        return new Directory
        {
            Id = id,
            Name = typeAccident.ToString()
        };
    }
}