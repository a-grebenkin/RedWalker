using System.Collections.Generic;
using System.Threading.Tasks;

namespace RedWalker.Core.Domains.Accidents.Services;

public interface IAccidentService
{
    Task<List<Accident>> GetAllAsync(); 
    Task<Accident> GetByIdAsync(int id);
}