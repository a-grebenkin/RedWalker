using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RedWalker.Core.Domains.Directories.Repositories;
using RedWalker.Core.Exceptions;
using RedWalker.Web.Controllers.Domains.Dto;

namespace RedWalker.Web.Controllers.Domains
{
    [ApiController]
    [Route("[controller]")]
    public class SceneAccidentController:ControllerBase
    {
        private readonly ISceneAccidentRepository _sceneAccidentRepository;

        public SceneAccidentController(ISceneAccidentRepository sceneAccidentRepository)
        {
            _sceneAccidentRepository = sceneAccidentRepository;
        }
        
        [HttpGet]
        public IEnumerable<DirectoryDto> GetAll()
        {
            var typeAccidents = _sceneAccidentRepository.GetAll();
            return typeAccidents.Select(typeAccident => new DirectoryDto
            {
                Id = typeAccident.Id,
                Name = typeAccident.Name
            });
        }
        
        [HttpGet("{id}")]
        public DirectoryDto GetById(string id)
        {
            var typeAccident = _sceneAccidentRepository.GetById(id);
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

