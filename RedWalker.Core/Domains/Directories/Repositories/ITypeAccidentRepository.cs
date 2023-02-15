using System.Collections.Generic;

namespace RedWalker.Core.Domains.Directories.Repositories;

public interface ITypeAccidentRepository
{
    public List<Directory> GetAll();
    public Directory GetById(string id);
}