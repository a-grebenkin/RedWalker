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
    public class TypeAccidentController: ControllerBase
    {
        private readonly ITypeAccidentService _typeAccidentService;

        public TypeAccidentController(ITypeAccidentService typeAccidentService)
        {
            _typeAccidentService = typeAccidentService;
        }

        [HttpGet]
        public IEnumerable<DirectoryDto> GetAll()
        {
            var typeAccidents = _typeAccidentService.GetAll();
            return typeAccidents.Select(typeAccident => new DirectoryDto
            {
                Id = typeAccident.Id,
                Name = typeAccident.Name
            });
        }
        [HttpGet("{id}")]
        public DirectoryDto GetById(string id)
        {
            var typeAccident = _typeAccidentService.GetById(id);
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

