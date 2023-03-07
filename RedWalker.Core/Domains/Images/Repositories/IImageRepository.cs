using System.Collections.Generic;
using System.Threading.Tasks;

namespace RedWalker.Core.Domains.Images.Repositories;

public interface IImageRepository
{
    Task<Image> GetByIdAsync(string id);
}