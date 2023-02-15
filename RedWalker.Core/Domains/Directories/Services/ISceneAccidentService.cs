using System.Collections.Generic;

namespace RedWalker.Core.Domains.Directories.Services;

public interface ISceneAccidentService
{
    public List<Directory> GetAll();
    public Directory GetById(string id);
}