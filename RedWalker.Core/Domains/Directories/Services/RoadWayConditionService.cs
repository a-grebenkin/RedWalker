using System.Collections.Generic;
using System.Threading.Tasks;
using RedWalker.Core.Domains.Directories.Repositories;

namespace RedWalker.Core.Domains.Directories.Services;

public class RoadWayConditionService : IRoadWayConditionService
{
    private readonly IRoadWayConditionRepository _roadWayConditionRepository;

    public RoadWayConditionService(IRoadWayConditionRepository roadWayConditionRepository)
    {
        _roadWayConditionRepository = roadWayConditionRepository;
    }
    public Task<List<Directory>> GetAllAsync()
    {
        return _roadWayConditionRepository.GetAllAsync();
    }

    public Task<Directory> GetByIdAsync(string id)
    {
        return _roadWayConditionRepository.GetByIdAsync(id);
    }
}