using System.Collections.Generic;
using System.Threading.Tasks;
using RedWalker.Core.Domains.Accidents.Repositories;

namespace RedWalker.Core.Domains.Accidents.Services;

public class AccidentService:IAccidentService
{
    private readonly IAccidentRepository _accidentRepository;

    public AccidentService(IAccidentRepository accidentRepository)
    {
        _accidentRepository = accidentRepository;
    }
    
    public Task<List<Accident>> GetAllAsync()
    {
        return _accidentRepository.GetAllAsync();
    }

    public Task<Accident> GetByIdAsync(int id)
    {
        return _accidentRepository.GetByIdAsync(id);;
    }
}