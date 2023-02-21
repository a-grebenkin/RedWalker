using System.Collections.Generic;
using System.Threading.Tasks;

namespace RedWalker.Core.Domains.Directories.Repositories;

public interface ISceneAccidentRepository
{
    public Task<List<Directory>> GetAllAsync();
    public Task<Directory> GetByIdAsync(string id);
}