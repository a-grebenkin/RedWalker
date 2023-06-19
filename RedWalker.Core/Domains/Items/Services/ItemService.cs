using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RedWalker.Core.Domains.Accidents;
using RedWalker.Core.Domains.GeoCoordinates;
using RedWalker.Core.Domains.Items.Repositories;
using RedWalker.Core.Domains.Weathers;
using RedWalker.Core.Paginates;

namespace RedWalker.Core.Domains.Items.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IWeatherForecast _weatherForecast;
        private readonly IConditionApproximator _conditionApproximator;
        private readonly IGeoCoordinatesComparer _coordinatesComparer;
        
        private const int MaxCount = 50;

        public ItemService(IItemRepository itemRepository, IWeatherForecast weatherForecast, IConditionApproximator conditionApproximator, IGeoCoordinatesComparer coordinatesComparer)
        {
            _itemRepository = itemRepository;
            _weatherForecast = weatherForecast;
            _conditionApproximator = conditionApproximator;
            _coordinatesComparer = coordinatesComparer;
        }
        public Task<List<Item>> GetAllAsync()
        {
            return _itemRepository.GetAllAsync();
        }

        public PagedList<Item> GetPaginated(PaginateParametrs paginateParametrs)
        {
            return _itemRepository.GetPaginated(paginateParametrs);
        }
        public async Task<List<Item>> GetForecastByLatLonRad(double lat, double lon, double radKm)
        {
            var items = await _itemRepository.GetAllAsync();
            var weatherForecast = await _weatherForecast.GetForecast(lat,lon);
            
            var values = new List<double>();
            
            var geoCoordinate2= new GeoCoordinate
            {
                Lat = lat,
                Lon = lon
            };

            var dateTimeNow = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "N. Central Asia Standard Time");
            foreach (var item in items)
            {
                foreach (var accident in item.Accidents)
                {
                    var weatherAccident = new WeatherModel
                    {
                        WeatherCondition = accident.WeatherDirectory.Id,
                        Temperature = accident.Temperature,
                        Cloudcover = accident.Cloudcover,
                        Precip = accident.Precip,
                        Visibility = accident.Visibility,
                        Windspeed = accident.Windspeed,
                        TimeSunrise = accident.TimeSunrise,
                        TimeSunset = accident.TimeSunset
                    };
                    var geoCoordinate1 = new GeoCoordinate
                    {
                        Lat = accident.Lat,
                        Lon = accident.Lon
                    };
                    
                    var proximityValue = _conditionApproximator.Approximate(
                        weatherAccident, weatherForecast, accident.DateTime, dateTimeNow);
                    var distanceValueFlag = _coordinatesComparer.EnteringAreaByKilometer(geoCoordinate1, geoCoordinate2,radKm);
                       
                    accident.ProximityValue = proximityValue;
                    accident.DistanceValueFlag = distanceValueFlag;
                    
                    values.Add(proximityValue);
                }
            }
            
            var thresholdValue = values.OrderBy(x=>x).Take(MaxCount).Last();
            return items.Select(x => new Item
            {
                Id = x.Id,
                Type = x.Type,
                Lat = x.Lat,
                Lon = x.Lon,
                RLat = x.RLat,
                RLon = x.RLon,
                Accidents = x.Accidents.Where(accident => accident.ProximityValue <= thresholdValue && accident.DistanceValueFlag).ToList(),
            }).Where(x => x.Accidents.Any()).Take(MaxCount).ToList();
        }
    }
}