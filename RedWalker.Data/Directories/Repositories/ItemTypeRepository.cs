using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RedWalker.Core.Domains.Directories;
using RedWalker.Core.Domains.Directories.Repositories;

namespace RedWalker.Data.Directories.Repositories;

public class ItemTypeRepository:IItemTypeRepository
{
    private readonly RedWalkerContext _context;

    public ItemTypeRepository(RedWalkerContext context)
    {
        _context = context;
    }

    public Task<List<Directory>> GetAllAsync()
    {
        return _context.ItemTypes.Select(item => new Directory
        {
            Id = item.StringId,
            Name = item.Name
        }).ToListAsync();
    }
    
    public async Task<Directory> GetByIdAsync(string id)
    {
        var itemType = await _context.ItemTypes.FirstOrDefaultAsync(condition => condition.StringId == id);
        if (itemType == null)
        {
            return null;
        }

        return new Directory
        {
            Id = itemType.StringId,
            Name = itemType.Name
        };
    }
}