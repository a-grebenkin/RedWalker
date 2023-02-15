using System.Collections.Generic;

namespace RedWalker.Core.Domains.Directories.Services;

public interface IRoadWayConditionService
{
    public List<Directory> GetAll();
    public Directory GetById(string id);
}