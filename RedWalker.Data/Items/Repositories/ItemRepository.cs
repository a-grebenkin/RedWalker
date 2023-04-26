
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RedWalker.Core.Domains.Accidents;
using RedWalker.Core.Domains.Directories;
using RedWalker.Core.Domains.Items;
using RedWalker.Core.Domains.Items.Repositories;

namespace RedWalker.Data.Items.Repositories
{
    public class ItemRepository:IItemRepository
    {
        private readonly RedWalkerContext _context;

        public ItemRepository(RedWalkerContext context)
        {
            _context = context;
        }
        public Task<List<Item>> GetAllAsync()
        {
            return _context.Items.
                Include(i=>i.Accidents).
                ThenInclude(a=>a.Lighting).
                Include(i=>i.Accidents).
                ThenInclude(a=>a.RoadWay).
                Include(i=>i.Accidents).
                ThenInclude(a=>a.SceneAccident).
                Include(i=>i.Accidents).
                ThenInclude(a=>a.AccidentType).
                Include(i=>i.Accidents).
                ThenInclude(a=>a.WeatherCondition).
                Select(item=> new Item 
                {
                Id = item.Id,
                Type = item.TypeItem.StringId,
                Lat = item.Lat,
                Lon = item.Lon,
                RLat = item.RLat,
                RLon = item.RLon,
                Accidents = item.Accidents.Select(accident => new Accident
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
                        Id = accident.AccidentType.StringId,
                        Name = accident.AccidentType.Name
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
                        Id = accident.WeatherCondition.StringId,
                        Name = accident.WeatherCondition.Name
                    },
                    TimeSunrise = accident.TimeSunrise,
                    TimeSunset = accident.TimeSunset
                }).ToList()

            }).ToListAsync();
        }
    }
}