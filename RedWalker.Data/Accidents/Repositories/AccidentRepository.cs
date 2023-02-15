using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RedWalker.Core.Domains.Accidents;
using RedWalker.Core.Domains.Accidents.Repositories;

namespace RedWalker.Data.Accidents.Repositories;

public class AccidentRepository:IAccidentRepository
{
    private readonly RedWalkerContext _context;

    public AccidentRepository(RedWalkerContext context)
    {
        _context = context;
    }
    
    public Task<List<Accident>> GetAllAsync()
    {
        return _context.Accidents.Select(accident => new Accident
        {
            Id = accident.Id,
            Adddres = accident.Adddres,
            Cloudcover = accident.Cloudcover,
            DateTime = accident.DateTime,
            Death = accident.Death,
            Lat = accident.Lat,
            Lighting = accident.Lighting,
            Lon = accident.Lon,
            Precip = accident.Precip,
            RoadWay = accident.RoadWay,
            Wounded = accident.Wounded,
            Type = accident.Type,
            Temperature = accident.Temperature,
            Visibility = accident.Visibility,
            Windspeed = accident.Windspeed,
            SceneAccident = accident.SceneAccident,
            Weather = accident.Weather
        }).ToListAsync();
    }

    public async Task<Accident> GetByIdAsync(int id)
    {
        var accident = await _context.Accidents.FirstOrDefaultAsync(a => a.Id == id);

        if (accident == null)
        {
            return null;
        }

        return new Accident
        {
            Id = accident.Id,
            Adddres = accident.Adddres,
            Cloudcover = accident.Cloudcover,
            DateTime = accident.DateTime,
            Death = accident.Death,
            Lat = accident.Lat,
            Lighting = accident.Lighting,
            Lon = accident.Lon,
            Precip = accident.Precip,
            RoadWay = accident.RoadWay,
            Wounded = accident.Wounded,
            Type = accident.Type,
            Temperature = accident.Temperature,
            Visibility = accident.Visibility,
            Windspeed = accident.Windspeed,
            SceneAccident = accident.SceneAccident,
            Weather = accident.Weather
        };
    }
}