using System.Collections.Generic;

namespace RedWalker.Core.Domains.Directories.Services;

public interface ITypeAccidentService
{
    public List<Directory> GetAll();
    public Directory GetById(string id);
}