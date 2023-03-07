using System.Collections.Generic;
using System.Threading.Tasks;

namespace RedWalker.Core.Domains.Images.Services;

public interface IImageService
{
    Task<Image> GetByIdAsync(string id);
}