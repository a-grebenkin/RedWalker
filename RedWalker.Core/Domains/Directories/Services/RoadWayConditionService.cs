using System.Collections.Generic;
using RedWalker.Core.Domains.Directories.Repositories;

namespace RedWalker.Core.Domains.Directories.Services;

public class RoadWayConditionService : IRoadWayConditionService
{
    private readonly IRoadWayConditionRepository _roadWayConditionRepository;

    public RoadWayConditionService(IRoadWayConditionRepository roadWayConditionRepository)
    {
        _roadWayConditionRepository = roadWayConditionRepository;
    }
    public List<Directory> GetAll()
    {
        return _roadWayConditionRepository.GetAll();
    }

    public Directory GetById(string id)
    {
        return _roadWayConditionRepository.GetById(id);
    }
}