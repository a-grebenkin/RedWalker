using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RedWalker.Core.Domains.Accidents;
using RedWalker.Core.Domains.Directories;
using RedWalker.Core.Domains.Directories.Repositories;

namespace RedWalker.Data.Directories.Repositories;

public class RoadWayConditionRepository:IRoadWayConditionRepository
{
    private readonly RedWalkerContext _context;

    public RoadWayConditionRepository(RedWalkerContext context)
    {
        _context = context;
    }
    /*private enum RoadWayCondition
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
    };*/
    public Task<List<Directory>> GetAllAsync()
    {
        return _context.RoadWayConditions.Select(condition => new Directory
        {
            Id = condition.StringId,
            Name = condition.Name
        }).ToListAsync();
    }

    public async Task<Directory> GetByIdAsync(string id)
    {
        var condition = await _context.RoadWayConditions.FirstOrDefaultAsync(condition => condition.StringId == id);
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