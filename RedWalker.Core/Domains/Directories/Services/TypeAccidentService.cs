using System.Collections.Generic;
using System.Threading.Tasks;
using RedWalker.Core.Domains.Directories.Repositories;

namespace RedWalker.Core.Domains.Directories.Services;

public class TypeAccidentService: ITypeAccidentService
{
    private readonly ITypeAccidentRepository _typeAccidentRepository;

    public TypeAccidentService(ITypeAccidentRepository typeAccidentRepository)
    {
        _typeAccidentRepository = typeAccidentRepository;
    }

    public Task<List<Directory>> GetAllAsync()
    {
        return _typeAccidentRepository.GetAllAsync();
    }

    public Task<Directory> GetByIdAsync(string id)
    {
        return _typeAccidentRepository.GetByIdAsync(id);
    }
}