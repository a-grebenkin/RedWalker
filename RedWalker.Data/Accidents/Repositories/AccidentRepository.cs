using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RedWalker.Core.Domains.Accidents;
using RedWalker.Core.Domains.Accidents.Repositories;
using RedWalker.Core.Domains.Directories;

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
        return _context.Accidents.
            Include(a=>a.Lighting).
            Include(a=>a.RoadWay).
            Include(a=>a.SceneAccident).
            Include(a=>a.Type).
            Include(a=>a.Weather).
            Select(accident => new Accident
        {
            Id = accident.Id,
            Adddres = accident.Adddres,
            Cloudcover = accident.Cloudcover,
            DateTime = accident.DateTime,
            Death = accident.Death,
            Lat = accident.Lat,
            LightingDirectory = new Directory
            {
                Id = accident.Lighting.StringId,
                Name = accident.Lighting.Name
            },
            Lon = accident.Lon,
            Precip = accident.Precip,
            RoadWayDirectory = new Directory
            {
                Id = accident.RoadWay.StringId,
                Name = accident.RoadWay.Name
            },
            Wounded = accident.Wounded,
            TypeDirectory = new Directory
            {
                Id = accident.Type.StringId,
                Name = accident.Type.Name
            },
            Temperature = accident.Temperature,
            Visibility = accident.Visibility,
            Windspeed = accident.Windspeed,
            SceneAccidentDirectory = new Directory
            {
                Id = accident.SceneAccident.StringId,
                Name = accident.SceneAccident.Name
            },
            WeatherDirectory = new Directory
            {
                Id = accident.Weather.StringId,
                Name = accident.Weather.Name
            }
        }).ToListAsync();
    }

    public async Task<Accident> GetByIdAsync(int id)
    {
        var accident = await _context.Accidents.
            Include(a=>a.Lighting).
            Include(a=>a.RoadWay).
            Include(a=>a.SceneAccident).
            Include(a=>a.Type).
            Include(a=>a.Weather).
            FirstOrDefaultAsync(a => a.Id == id);

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
            LightingDirectory = new Directory
            {
                Id = accident.Lighting.StringId,
                Name = accident.Lighting.Name
            },
            Lon = accident.Lon,
            Precip = accident.Precip,
            RoadWayDirectory = new Directory
            {
                Id = accident.RoadWay.StringId,
                Name = accident.RoadWay.Name
            },
            Wounded = accident.Wounded,
            TypeDirectory = new Directory
            {
                Id = accident.Type.StringId,
                Name = accident.Type.Name
            },
            Temperature = accident.Temperature,
            Visibility = accident.Visibility,
            Windspeed = accident.Windspeed,
            SceneAccidentDirectory = new Directory
            {
                Id = accident.SceneAccident.StringId,
                Name = accident.SceneAccident.Name
            },
            WeatherDirectory = new Directory
            {
                Id = accident.Weather.StringId,
                Name = accident.Weather.Name
            }
        };
    }
}