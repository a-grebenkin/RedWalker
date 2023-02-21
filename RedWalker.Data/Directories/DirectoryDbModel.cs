using System.Collections.Generic;
using RedWalker.Data.Accidents;

namespace RedWalker.Data.Directories;

public class DirectoryDbModel
{
    public int Id { get; set; }
    public string StringId { get; set; }
    public string Name { get; set; }
    public List<AccidentDbModel> Accidents  { get; set; }
}