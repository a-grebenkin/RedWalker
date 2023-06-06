using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RedWalker.Core.Domains.Accidents;
using RedWalker.Core.Domains.GeoCoordinates;
using RedWalker.Core.Domains.Items.Repositories;
using RedWalker.Core.Domains.Weathers;

namespace RedWalker.Core.Domains.Items.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly IWeatherForecast _weatherForecast;
        private readonly IConditionApproximator _conditionApproximator;
        private readonly IGeoCoordinatesComparer _coordinatesComparer;

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

        public async Task<List<Item>> GetForecastByLatLonRad(double lat, double lon, double radKm)
        {
            var items = await _itemRepository.GetAllAsync();
            var weatherForecast = await _weatherForecast.GetForecast(lat,lon);


            var itemsForecast = new List<Item>();
            foreach (var item in items)
            {
                var accidentsForecast = new List<Accident>();
                foreach (var accident in item.Accidents)
                {
                    var geoCoordinate1 = new GeoCoordinate
                    {
                        Lat = accident.Lat,
                        Lon = accident.Lon
                    };
                    var geoCoordinate2= new GeoCoordinate
                    {
                        Lat = lat,
                        Lon = lon
                    };
                    if (!_coordinatesComparer.EnteringAreaByKilometer(geoCoordinate1,geoCoordinate2,radKm))
                    {
                        continue;
                    }
                    
                    var weatherAccident = new WeatherModel
                    {
                        Temperature = accident.Temperature,
                        Cloudcover = accident.Cloudcover,
                        Precip = accident.Precip,
                        Visibility = accident.Visibility,
                        Windspeed = accident.Windspeed,
                        TimeSunrise = accident.TimeSunrise,
                        TimeSunset = accident.TimeSunset
                    };
                    if (!_conditionApproximator.Approximate(weatherAccident, weatherForecast, accident.DateTime, DateTime.Now))
                    {
                        continue;
                    }
                    accidentsForecast.Add(accident);
                }

                if (accidentsForecast.Count > 0)
                {
                    var itemForecast = item;
                    itemForecast.Accidents = accidentsForecast;
                    itemsForecast.Add(itemForecast);
                }
            }
            return itemsForecast;
        }
    }
}