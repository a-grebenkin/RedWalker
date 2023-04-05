using System.Collections.Generic;
using System.Threading.Tasks;

namespace RedWalker.Core.Domains.Directories.Repositories;

public interface IItemTypeRepository
{
    public Task<List<Directory>> GetAllAsync();
}