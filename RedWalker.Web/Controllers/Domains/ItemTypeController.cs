using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RedWalker.Core.Domains.Directories.Services;
using RedWalker.Core.Exceptions;
using RedWalker.Web.Controllers.Domains.Dto;

namespace RedWalker.Web.Controllers.Domains;

[ApiController]
[Route("[controller]")]
public class ItemTypeController: ControllerBase
{
    private readonly IItemTypeService _itemTypeService;

    public ItemTypeController(IItemTypeService itemTypeService)
    {
        _itemTypeService = itemTypeService;
    }

    [HttpGet]
    public async Task<IEnumerable<DirectoryDto>> GetAll()
    {
        var itemTypes = await _itemTypeService.GetAllAsync();
        return  itemTypes.Select(itemType => new DirectoryDto()
        {
            Id = itemType.Id,
            Name = itemType.Name
        });
    }
    
    [HttpGet("{id}")]
    public async Task<DirectoryDto> GetById(string id)
    {
        var typeAccident = await _itemTypeService.GetByIdAsync(id);
        if (typeAccident == null)
        {
            throw new ValidationException("Тип места концентрации ДТП с указанным ID не найден");
        }

        return new DirectoryDto
        {
            Id = typeAccident.Id,
            Name = typeAccident.Name
        };
    }
}