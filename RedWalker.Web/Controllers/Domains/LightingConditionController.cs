using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RedWalker.Core.Domains.Directories.Services;
using RedWalker.Core.Exceptions;
using RedWalker.Web.Controllers.Domains.Dto;

namespace RedWalker.Web.Controllers.Domains;

public class LightingConditionController : ControllerBase
{
    private readonly ILightingConditionService _lightingConditionService;

    public LightingConditionController(ILightingConditionService lightingConditionService)
    {
        _lightingConditionService = lightingConditionService;
    }
    [HttpGet]
    public IEnumerable<DirectoryDto> GetAll()
    {
        var typeAccidents = _lightingConditionService.GetAll();
        return typeAccidents.Select(typeAccident => new DirectoryDto
        {
            Id = typeAccident.Id,
            Name = typeAccident.Name
        });
    }
        
    [HttpGet("{id}")]
    public DirectoryDto GetById(string id)
    {
        var typeAccident = _lightingConditionService.GetById(id);
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