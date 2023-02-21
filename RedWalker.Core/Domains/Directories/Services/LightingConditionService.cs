using System.Collections.Generic;
using System.Threading.Tasks;
using RedWalker.Core.Domains.Directories.Repositories;

namespace RedWalker.Core.Domains.Directories.Services;

public class LightingConditionService:ILightingConditionService
{
    private readonly ILightingConditionRepository _lightingConditionRepository;

    public LightingConditionService(ILightingConditionRepository lightingConditionRepository)
    {
        _lightingConditionRepository = lightingConditionRepository;
    }
    public Task<List<Directory>> GetAllAsync()
    {
        return _lightingConditionRepository.GetAllAsync();
    }

    public Task<Directory> GetByIdGetAllAsync(string id)
    {
        return _lightingConditionRepository.GetByIdAsync(id);
    }
}