using System.Collections.Generic;
using System.Threading.Tasks;
using RedWalker.Core.Domains.Directories.Repositories;

namespace RedWalker.Core.Domains.Directories.Services;

public class AccidentTypeService: IAccidentTypeService
{
    private readonly IAccidentTypeRepository _accidentTypeRepository;

    public AccidentTypeService(IAccidentTypeRepository accidentTypeRepository)
    {
        _accidentTypeRepository = accidentTypeRepository;
    }

    public Task<List<Directory>> GetAllAsync()
    {
        return _accidentTypeRepository.GetAllAsync();
    }

    public Task<Directory> GetByIdAsync(string id)
    {
        return _accidentTypeRepository.GetByIdAsync(id);
    }
}