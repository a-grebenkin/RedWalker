﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RedWalker.Core.Domains.Accidents.Services;
using RedWalker.Core.Exceptions;
using WebApplication.Controllers.Accidents.Dto;

namespace RedWalker.Web.Controllers.Accidents
{
    [ApiController]
    [Route("[controller]")]
    public class AccidentController: ControllerBase
    {
        private readonly IAccidentService _accidentService;

        public AccidentController(IAccidentService accidentService)
        {
            _accidentService = accidentService;
        }

        [HttpGet]
        public async Task<IEnumerable<AccidentDto>> GetAll()
        {
            var accidents = await _accidentService.GetAllAsync();
            return accidents.Select(accident => new AccidentDto
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
            });
        }
        
        [HttpGet("{id}")]
        public async Task<AccidentDto> GetById(int id)
        {
            var accident = await _accidentService.GetByIdAsync(id);
            if (accident == null)
            {
                throw new ValidationException("Происшествие с указанным ID не найдено");
            }
            return new AccidentDto
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
}

