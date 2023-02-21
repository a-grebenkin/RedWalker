using System.Collections.Generic;
using System.Threading.Tasks;
using RedWalker.Core.Domains.Directories.Repositories;

namespace RedWalker.Core.Domains.Directories.Services;

public class WeatherConditionService: IWeatherConditionService
{
    private readonly IWeatherConditionRepository _weatherConditionRepository;

    public WeatherConditionService(IWeatherConditionRepository weatherConditionRepository)
    {
        _weatherConditionRepository = weatherConditionRepository;
    }
    public Task<List<Directory>> GetAllAsync()
    {
        return _weatherConditionRepository.GetAllAsync();
    }

    public Task<Directory> GetByIdAsync(string id)
    {
        return _weatherConditionRepository.GetByIdAsync(id);
    }
}