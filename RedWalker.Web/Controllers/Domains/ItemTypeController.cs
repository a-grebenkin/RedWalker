using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RedWalker.Core.Domains.Directories;
using RedWalker.Core.Domains.Directories.Services;

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
    public async Task<IEnumerable<Directory>> GetAll()
    {
        var itemTypes = await _itemTypeService.GetAllAsync();
        return  itemTypes.Select(itemType => new Directory()
        {
            Id = itemType.Id,
            Name = itemType.Name
        });
    }
}