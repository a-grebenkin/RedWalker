using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RedWalker.Core.Domains.Accidents;
using RedWalker.Core.Domains.Directories;
using RedWalker.Core.Domains.Directories.Repositories;

namespace RedWalker.Data.Directories.Repositories;

public class WeatherConditionRepository:IWeatherConditionRepository
{
    private readonly RedWalkerContext _context;

    public WeatherConditionRepository(RedWalkerContext context)
    {
        _context = context;
    }
    /*private enum WeatherCondition
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
    };*/
    public Task<List<Directory>> GetAllAsync()
    {
        return _context.WeatherConditions.Select(condition => new Directory
        {
            Id = condition.StringId,
            Name = condition.Name
        }).ToListAsync();
    }

    public async Task<Directory> GetByIdAsync(string id)
    {
        var condition = await _context.WeatherConditions.FirstOrDefaultAsync(condition => condition.StringId == id);
        if (condition == null)
        {
            return null;
        }

        return new Directory
        {
            Id = condition.StringId,
            Name = condition.Name
        };
    }
}