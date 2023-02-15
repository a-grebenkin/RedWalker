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
    public class RoadWayConditionController:ControllerBase
    {
        private readonly IRoadWayConditionService _roadWayConditionService;

        public RoadWayConditionController(IRoadWayConditionService roadWayConditionService)
        {
            _roadWayConditionService = roadWayConditionService;
        }
        [HttpGet]
        public IEnumerable<DirectoryDto> GetAll()
        {
            var typeAccidents = _roadWayConditionService.GetAll();
            return typeAccidents.Select(typeAccident => new DirectoryDto
            {
                Id = typeAccident.Id,
                Name = typeAccident.Name
            });
        }
        
        [HttpGet("{id}")]
        public DirectoryDto GetById(string id)
        {
            var typeAccident = _roadWayConditionService.GetById(id);
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
