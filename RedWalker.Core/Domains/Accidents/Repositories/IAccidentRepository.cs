using System.Collections.Generic;
using System.Threading.Tasks;

namespace RedWalker.Core.Domains.Accidents.Repositories;

public interface IAccidentRepository
{
    Task<List<Accident>> GetAllAsync();
    Task<Accident> GetByIdAsync(int id);
}