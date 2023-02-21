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
    public class TypeAccidentController: ControllerBase
    {
        private readonly ITypeAccidentService _typeAccidentService;

        public TypeAccidentController(ITypeAccidentService typeAccidentService)
        {
            _typeAccidentService = typeAccidentService;
        }

        [HttpGet]
        public async Task<IEnumerable<DirectoryDto>> GetAll()
        {
            var typeAccidents = await _typeAccidentService.GetAllAsync();
            return typeAccidents.Select(typeAccident => new DirectoryDto
            {
                Id = typeAccident.Id,
                Name = typeAccident.Name
            });
        }
        [HttpGet("{id}")]
        public async Task<DirectoryDto> GetById(string id)
        {
            var typeAccident = await _typeAccidentService.GetByIdAsync(id);
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

