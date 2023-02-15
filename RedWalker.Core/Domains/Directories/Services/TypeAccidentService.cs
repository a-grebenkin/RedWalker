using System.Collections.Generic;
using RedWalker.Core.Domains.Directories.Repositories;

namespace RedWalker.Core.Domains.Directories.Services;

public class TypeAccidentService: ITypeAccidentService
{
    private readonly ITypeAccidentRepository _typeAccidentRepository;

    public TypeAccidentService(ITypeAccidentRepository typeAccidentRepository)
    {
        _typeAccidentRepository = typeAccidentRepository;
    }

    public List<Directory> GetAll()
    {
        return _typeAccidentRepository.GetAll();
    }

    public Directory GetById(string id)
    {
        return _typeAccidentRepository.GetById(id);
    }
}