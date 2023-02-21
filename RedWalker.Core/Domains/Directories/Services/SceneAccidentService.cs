using System.Collections.Generic;
using System.Threading.Tasks;
using RedWalker.Core.Domains.Directories.Repositories;

namespace RedWalker.Core.Domains.Directories.Services;

public class SceneAccidentService : ISceneAccidentService
{
    private readonly ISceneAccidentRepository _sceneAccidentRepository;

    public SceneAccidentService(ISceneAccidentRepository sceneAccidentRepository)
    {
        _sceneAccidentRepository = sceneAccidentRepository;
    }
    public Task<List<Directory>> GetAllAsync()
    {
        return _sceneAccidentRepository.GetAllAsync();
    }

    public Task<Directory> GetByIdAsync(string id)
    {
        return _sceneAccidentRepository.GetByIdAsync(id);
    }
}