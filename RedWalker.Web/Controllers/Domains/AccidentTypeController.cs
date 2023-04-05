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
    public class AccidentTypeController: ControllerBase
    {
        private readonly IAccidentTypeService _accidentTypeService;

        public AccidentTypeController(IAccidentTypeService accidentTypeService)
        {
            _accidentTypeService = accidentTypeService;
        }

        [HttpGet]
        public async Task<IEnumerable<DirectoryDto>> GetAll()
        {
            var accidentTypes = await _accidentTypeService.GetAllAsync();
            return accidentTypes.Select(accidentType => new DirectoryDto
            {
                Id = accidentType.Id,
                Name = accidentType.Name
            });
        }
        [HttpGet("{id}")]
        public async Task<DirectoryDto> GetById(string id)
        {
            var typeAccident = await _accidentTypeService.GetByIdAsync(id);
            if (typeAccident == null)
            {
                throw new ValidationException("Тип происшествия с указанным ID не найден");
            }

            return new DirectoryDto
            {
                Id = typeAccident.Id,
                Name = typeAccident.Name
            };
        }
    }
}

