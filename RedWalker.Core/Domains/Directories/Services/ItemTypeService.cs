using System.Collections.Generic;
using System.Threading.Tasks;
using RedWalker.Core.Domains.Directories.Repositories;

namespace RedWalker.Core.Domains.Directories.Services;

public class ItemTypeService:IItemTypeService
{
    private readonly IItemTypeRepository _itemTypeRepository;

    public ItemTypeService(IItemTypeRepository itemTypeRepository)
    {
        _itemTypeRepository = itemTypeRepository;
    }
    public Task<List<Directory>> GetAllAsync()
    {
        return _itemTypeRepository.GetAllAsync();
    }
}