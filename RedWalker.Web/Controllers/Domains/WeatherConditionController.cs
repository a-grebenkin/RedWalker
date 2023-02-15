using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RedWalker.Core.Domains.Directories.Services;
using RedWalker.Core.Exceptions;
using RedWalker.Web.Controllers.Domains.Dto;

namespace RedWalker.Web.Controllers.Domains
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherConditionController: ControllerBase
    {
        private readonly IWeatherConditionService _weatherConditionService;

        public WeatherConditionController(IWeatherConditionService weatherConditionService)
        {
            _weatherConditionService = weatherConditionService;
        }
        
        [HttpGet]
        public IEnumerable<DirectoryDto> GetAll()
        {
            var typeAccidents = _weatherConditionService.GetAll();
            return typeAccidents.Select(typeAccident => new DirectoryDto
            {
                Id = typeAccident.Id,
                Name = typeAccident.Name
            });
        }
        
        [HttpGet("{id}")]
        public DirectoryDto GetById(string id)
        {
            var typeAccident = _weatherConditionService.GetById(id);
            if (typeAccident == null)
            {
                throw new ValidationException("Погодные условия с указанным ID не найдены");
            }

            return new DirectoryDto
            {
                Id = typeAccident.Id,
                Name = typeAccident.Name
            };
        }
    }
}

