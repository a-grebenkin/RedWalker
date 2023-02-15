using System.Collections.Generic;
using RedWalker.Core.Domains.Directories.Repositories;

namespace RedWalker.Core.Domains.Directories.Services;

public class LightingConditionService:ILightingConditionService
{
    private readonly ILightingConditionRepository _lightingConditionRepository;

    public LightingConditionService(ILightingConditionRepository lightingConditionRepository)
    {
        _lightingConditionRepository = lightingConditionRepository;
    }
    public List<Directory> GetAll()
    {
        return _lightingConditionRepository.GetAll();
    }

    public Directory GetById(string id)
    {
        return _lightingConditionRepository.GetById(id);
    }
}