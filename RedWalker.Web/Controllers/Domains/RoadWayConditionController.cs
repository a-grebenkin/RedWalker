using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<IEnumerable<DirectoryDto>> GetAll()
        {
            var typeAccidents = await _roadWayConditionService.GetAllAsync();
            return typeAccidents.Select(typeAccident => new DirectoryDto
            {
                Id = typeAccident.Id,
                Name = typeAccident.Name
            });
        }
        
        [HttpGet("{id}")]
        public async Task<DirectoryDto> GetById(string id)
        {
            var typeAccident = await _roadWayConditionService.GetByIdAsync(id);
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
