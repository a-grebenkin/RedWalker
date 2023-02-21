using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RedWalker.Core.Domains.Directories;
using RedWalker.Core.Domains.Directories.Repositories;

namespace RedWalker.Data.Directories.Repositories;

public class LightingConditionRepository:ILightingConditionRepository
{
    private readonly RedWalkerContext _context;

    public LightingConditionRepository(RedWalkerContext context)
    {
        _context = context;
    }
    /*private enum LightingCondition
    {
        Daylight, // Светлое время суток
        Twilight, // Сумерки
        DarkTimeNoLight, // В темное время суток, освещение отсутствует
        DarkTimeLightOn, // В темное время суток, освещение включено
        DarkTimeLightOff // В темное время суток, освещение не включено
    }

    private static readonly Dictionary<LightingCondition,string> DictLightingCondition = new(){
        {LightingCondition.Daylight,"Светлое время суток"},
        {LightingCondition.Twilight, "Сумерки"},
        {LightingCondition.DarkTimeNoLight, "В темное время суток, освещение отсутствует"},
        {LightingCondition.DarkTimeLightOn, "В темное время суток, освещение включено"},
        {LightingCondition.DarkTimeLightOff, "В темное время суток, освещение не включено"}
    };*/
    public Task<List<Directory>> GetAllAsync()
    {
        return _context.LightingConditions.Select(condition => new Directory
        {
            Id = condition.StringId,
            Name = condition.Name
        }).ToListAsync();
    }

    public async Task<Directory> GetByIdAsync(string id)
    {
        var condition = await _context.LightingConditions.FirstOrDefaultAsync(condition => condition.StringId == id);
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