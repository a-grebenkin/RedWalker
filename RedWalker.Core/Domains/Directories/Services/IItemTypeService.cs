using System.Collections.Generic;
using System.Threading.Tasks;

namespace RedWalker.Core.Domains.Directories.Services;

public interface IItemTypeService
{
    public Task<List<Directory>> GetAllAsync();
}