using System.Collections.Generic;

namespace RedWalker.Core.Domains.Directories.Services;

public interface IWeatherConditionService
{
    public List<Directory> GetAll();
    public Directory GetById(string id);
}