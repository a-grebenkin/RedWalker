using System.Collections.Generic;
using RedWalker.Core.Domains.Directories.Repositories;

namespace RedWalker.Core.Domains.Directories.Services;

public class WeatherConditionService: IWeatherConditionService
{
    private readonly IWeatherConditionRepository _weatherConditionRepository;

    public WeatherConditionService(IWeatherConditionRepository weatherConditionRepository)
    {
        _weatherConditionRepository = weatherConditionRepository;
    }
    public List<Directory> GetAll()
    {
        return _weatherConditionRepository.GetAll();
    }

    public Directory GetById(string id)
    {
        return _weatherConditionRepository.GetById(id);
    }
}