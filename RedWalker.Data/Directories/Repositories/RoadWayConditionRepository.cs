using System;
using System.Collections.Generic;
using System.Linq;
using RedWalker.Core.Domains.Directories;
using RedWalker.Core.Domains.Directories.Repositories;

namespace RedWalker.Data.Directories.Repositories;

public class RoadWayConditionRepository:IRoadWayConditionRepository
{
    private enum RoadWayCondition
    {
        Dry, //Сухое
        Wet, //Мокрое
        Dusty, //Пыльное
        SnowСovered, //Заснеженное
        Contaminated,//Загрязненное
        SnowTrack, //Со снежным накатом
        Icy, //Гололедица
        AntiIcing, //Обработанное противогололедными материалами
        SurfaceTreatment,//Свежеуложенная поверхностная обработка
        CoveredWater//Залитое (покрытое) водой
    }

    private static readonly Dictionary<RoadWayCondition, string> DictRoadWayCondition = new(){
        {RoadWayCondition.Dry, "Сухое"},
        {RoadWayCondition.Wet, "Мокрое"},
        {RoadWayCondition.Dusty, "Пыльное"},
        {RoadWayCondition.SnowСovered, "Заснеженное"},
        {RoadWayCondition.Contaminated, "Загрязненное"},
        {RoadWayCondition.SnowTrack, "Со снежным накатом"},
        {RoadWayCondition.Icy, "Гололедица"},
        {RoadWayCondition.AntiIcing, "Обработанное противогололедными материалами"},
        {RoadWayCondition.SurfaceTreatment, "Свежеуложенная поверхностная обработка"},
        {RoadWayCondition.CoveredWater, "Залитое (покрытое) водой"}
    };
    public List<Directory> GetAll()
    {
        return DictRoadWayCondition.Select(dict => new Directory
        {
            Id = dict.Key.ToString(),
            Name = dict.Value
        }).ToList();
    }

    public Directory GetById(string id)
    {
        if (!Enum.TryParse(id, out RoadWayCondition key))
        {
            return null;
        }
        if (!DictRoadWayCondition.TryGetValue(key, out var typeAccident))
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