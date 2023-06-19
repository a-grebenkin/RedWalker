using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RedWalker.Core.Domains.Items.Services;
using RedWalker.Core.Paginates;
using RedWalker.Web.Controllers.Items.Dto;
using WebApplication.Controllers.Accidents.Dto;
using WebApplication.Controllers.Items.Dto;

namespace RedWalker.Web.Controllers.Items
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }
        /*
        [HttpGet]
        public async Task<IEnumerable<ItemDto>> GetAll()
        {
            var items =  await _itemService.GetAllAsync();
            return items.Select(item => new ItemDto
            {
                Id = item.Id,
                Type = item.Type,
                Lat = item.Lat,
                Lon = item.Lon,
                RLat = item.RLat,
                RLon = item.RLon,
                Wounded = item.Accidents.Sum(x=>x.Wounded),
                Death = item.Accidents.Sum(x=>x.Death),
                Accidents = item.Accidents.Select(accident => new AccidentShortDto
                {
                    Id = accident.Id,
                    Death = accident.Death,
                    Wounded = accident.Wounded,
                    DateTime = accident.DateTime,
                    Temperature = accident.Temperature,
                    Precip = accident.Precip,
                    Visibility = accident.Visibility,
                    Windspeed = accident.Windspeed,
                    Cloudcover = accident.Cloudcover,
                    AccidentType = accident.TypeDirectory.Id,
                    Lighting = accident.LightingDirectory.Id,
                    RoadWay = accident.RoadWayDirectory.Id,
                    Weather = accident.WeatherDirectory.Id,
                }).ToList()
            });
        }
        */
        [HttpGet]
        public IEnumerable<ItemDto> GetPaginated([FromQuery] PaginateParametrs paginateParametrs)
        {
            var items =  _itemService.GetPaginated(paginateParametrs);
            var metadata = new
            {
                items.TotalCount,
                items.PageSize,
                items.CurrentPage,
                items.TotalPages,
                items.HasNext,
                items.HasPrevious
            };
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return items.Select(item => new ItemDto
            {
                Id = item.Id,
                Type = item.Type,
                Lat = item.Lat,
                Lon = item.Lon,
                RLat = item.RLat,
                RLon = item.RLon,
                Wounded = item.Accidents.Sum(x=>x.Wounded),
                Death = item.Accidents.Sum(x=>x.Death),
                Accidents = item.Accidents.Select(accident => new AccidentShortDto
                {
                    Id = accident.Id,
                    Death = accident.Death,
                    Wounded = accident.Wounded,
                    DateTime = accident.DateTime,
                    Temperature = accident.Temperature,
                    Precip = accident.Precip,
                    Visibility = accident.Visibility,
                    Windspeed = accident.Windspeed,
                    Cloudcover = accident.Cloudcover,
                    AccidentType = accident.TypeDirectory.Id,
                    Lighting = accident.LightingDirectory.Id,
                    RoadWay = accident.RoadWayDirectory.Id,
                    Weather = accident.WeatherDirectory.Id,
                }).ToList()
            });
        }
        [HttpGet ("Forecast")]
        public async Task<IEnumerable<ItemDto>> GetForecastByLatLonRad(double lat, double lon, double radKm)
        {
            var items =  await _itemService.GetForecastByLatLonRad(lat, lon, radKm);
            //return TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "N. Central Asia Standard Time");
            return items.Select(item => new ItemDto
            {
                Id = item.Id,
                Type = item.Type,
                Lat = item.Lat,
                Lon = item.Lon,
                RLat = item.RLat,
                RLon = item.RLon,
                Wounded = item.Accidents.Sum(x=>x.Wounded),
                Death = item.Accidents.Sum(x=>x.Death),
                Accidents = item.Accidents.Select(accident => new AccidentShortDto
                {
                    Id = accident.Id,
                    Death = accident.Death,
                    Wounded = accident.Wounded,
                    DateTime = accident.DateTime,
                    Temperature = accident.Temperature,
                    Precip = accident.Precip,
                    Visibility = accident.Visibility,
                    Windspeed = accident.Windspeed,
                    Cloudcover = accident.Cloudcover,
                    AccidentType = accident.TypeDirectory.Id,
                    Lighting = accident.LightingDirectory.Id,
                    RoadWay = accident.RoadWayDirectory.Id,
                    Weather = accident.WeatherDirectory.Id
                }).ToList()
            });
        }
    }
}

