
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
            return _context.Items.Select(item=> new Item
            {
                Id = item.Id,
                Type = item.Type,
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
                        Id = "test",
                        Name = "test"
                    },
                    Lon = accident.Lon,
                    Precip = accident.Precip,
                    RoadWayDirectory = new Directory
                    {
                        Id = "test",
                        Name = "test"
                    },
                    Wounded = accident.Wounded,
                    TypeDirectory = new Directory
                    {
                        Id = "test",
                        Name = "test"
                    },
                    Temperature = accident.Temperature,
                    Visibility = accident.Visibility,
                    Windspeed = accident.Windspeed,
                    SceneAccidentDirectory = new Directory
                    {
                        Id = "test",
                        Name = "test"
                    },
                    WeatherDirectory = new Directory
                    {
                        Id = "test",
                        Name = "test"
                    }
                }).ToList()

            }).ToListAsync();
        }
    }
}