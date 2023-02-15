using System;
using System.Collections.Generic;
using System.Linq;
using RedWalker.Core.Domains.Directories;
using RedWalker.Core.Domains.Directories.Repositories;

namespace RedWalker.Data.Directories.Repositories;

public class LightingConditionRepository:ILightingConditionRepository
{
    private enum LightingCondition
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
    };
    public List<Directory> GetAll()
    {
        return DictLightingCondition.Select(dict => new Directory
        {
            Id = dict.Key.ToString(),
            Name = dict.Value
        }).ToList();
    }

    public Directory GetById(string id)
    {
        if (!Enum.TryParse(id, out LightingCondition key))
        {
            return null;
        }
        if (!DictLightingCondition.TryGetValue(key, out var typeAccident))
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