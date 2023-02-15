using System.Collections.Generic;
using RedWalker.Core.Domains.Directories.Repositories;

namespace RedWalker.Core.Domains.Directories.Services;

public class SceneAccidentService : ISceneAccidentService
{
    private readonly ISceneAccidentRepository _sceneAccidentRepository;

    public SceneAccidentService(ISceneAccidentRepository sceneAccidentRepository)
    {
        _sceneAccidentRepository = sceneAccidentRepository;
    }
    public List<Directory> GetAll()
    {
        return _sceneAccidentRepository.GetAll();
    }

    public Directory GetById(string id)
    {
        return _sceneAccidentRepository.GetById(id);
    }
}