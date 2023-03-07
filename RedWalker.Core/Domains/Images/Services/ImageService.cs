using System.Collections.Generic;
using System.Threading.Tasks;
using RedWalker.Core.Domains.Images.Repositories;

namespace RedWalker.Core.Domains.Images.Services;

public class ImageService:IImageService
{
    private readonly IImageRepository _imageRepository;

    public ImageService(IImageRepository imageRepository)
    {
        _imageRepository = imageRepository;
    }
    public Task<Image> GetByIdAsync(string id)
    {
        return _imageRepository.GetByIdAsync(id);
    }
    
}