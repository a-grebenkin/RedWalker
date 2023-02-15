using System.Collections.Generic;

namespace RedWalker.Core.Domains.Directories.Repositories;

public interface IWeatherConditionRepository
{
    public List<Directory> GetAll();
    public Directory GetById(string id);
}